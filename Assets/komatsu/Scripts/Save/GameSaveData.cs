using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;
using System.IO;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

// ゲームフラグクラス
[MessagePackObject(keyAsPropertyName: true), Serializable]
public class GameFlag
{
    public string name;     // フラグ名
    public int value;       // フラグの値
}

// セーブデータのみのクラス
[MessagePackObject(keyAsPropertyName: true), Serializable]
public class SaveData
{
    // 所持しているアイテムボックスのリスト（保存対象に設定済み）
    public List<int> ItemBox = new List<int>();

    //　拾ったアイテムのリスト(過去に拾ったかどうか。今所持しているかどうかは関係ない）
    public List<int> PickedItems = new List<int>();

    // ゲームフラグのリスト(GameFlag型にしているのでnameとvalueの値を一緒に入れられる)
    public List<GameFlag> GameFlags = new List<GameFlag>();
}


// セーブデータ用ゲームオブジェクトクラス
// GameSaveData.Instance.saveDataという形でセーブデータに外部からアクセスができる
public class GameSaveData : MonoBehaviour
{
    public SaveData saveData;

    static GameSaveData _Instance = null;
    public static GameSaveData Instance { get { return _Instance; } }

    void Awake()
    {
        if (_Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _Instance = this;

        var resolver = MessagePack.Resolvers.CompositeResolver.Create(
            // 他のリゾルバを追加する場合はここに追加
            MessagePack.Resolvers.StandardResolver.Instance,
            MessagePack.Resolvers.GeneratedResolver.Instance
        );

        // MessagePackSerializerにリゾルバを設定
        MessagePack.MessagePackSerializer.DefaultOptions = MessagePack.MessagePackSerializerOptions.Standard.WithResolver(resolver);

        DontDestroyOnLoad(gameObject);
        Load();
    }

    // 指定ゲームフラグの値をチェックする処理
    public bool CheckGameFlag(string flagName, int value)
    {
        return saveData.GameFlags
            .Where(it => it.name == flagName)
            .Where(it => it.value == value)
            .Any();
    }

    public int GetGameFlag(string flagName)
    {
        var flag = saveData.GameFlags
            .Where(it => it.name == flagName)
            .FirstOrDefault();
        if (flag == null) return 0;
        return flag.value;
    }

    // 指定ゲームフラグの値を設定する処理
    public void SetGameFlag(string flagName, int value)
    {
        var flag = saveData.GameFlags
            .Where(it => it.name == flagName)
            .FirstOrDefault();

        // フラグが未登録なので、新しく作って登録してあげる
        if (flag == null)
        {
            flag = new GameFlag();
            flag.name = flagName;
            flag.value = value;
            saveData.GameFlags.Add(flag);
        }
        // 既にフラグが存在しているので、値だけを書き換える
        else
        {
            flag.value = value;
        }
    }


    // セーブ処理
    public void Save()
    {
        try
        {
            // クラスをjson化
            var serialized = MessagePackSerializer.Serialize(saveData);
            var json = MessagePackSerializer.ConvertToJson(serialized);

            // 保存
            string filePath = Application.persistentDataPath + "/" + "save.txt";
            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(json);
            sw.Flush();
            sw.Close();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    // ロード処理
    public void Load()
    {
        string filepath = Application.persistentDataPath + "/" + "save.txt";

        // ファイルがない場合は何もしない
        if (!File.Exists(filepath)) return;

        string json = "";
        using (StreamReader sr = new StreamReader(filepath))
        {
            json = sr.ReadToEnd();
        }

        var serialized = MessagePackSerializer.ConvertFromJson(json);
        saveData = MessagePackSerializer.Deserialize<SaveData>(serialized);
    }

    // アプリ終了時にオートセーブする場合
    // void OnApplicationQuit()
    // {
    //     Save();
    // }


    public void InitializeSaveData()
    {
       string filepath = Application.persistentDataPath + "/" + "save.txt";
        if (File.Exists(filepath))
        {
             try
             {
                  File.Delete(filepath);
                Debug.Log("Save file deleted successfully.");
            }
            catch (Exception e)
             {
                Debug.LogError("Error deleting save file: " + e.Message);
            }
        }
        Debug.Log(File.Exists(filepath));
        Save();

    }

}
