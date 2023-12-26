using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;


    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 引数で指定したシーンへのシーン遷移の準備
　　/// シーン遷移を実行する場合は、このメソッドを利用する
    /// </summary>
    /// <param name="nextSceneType"></param>
    public void PreparateNextScene(SceneType nextSceneType) 
    {
　　　　// 引数で指定したシーンへ遷移
        StartCoroutine(LoadNextScene(nextSceneType));
    }

    /// <summary>
    /// 引数で指定したシーンへ遷移
    /// </summary>
    /// <param name="nextLoadSceneName"></param>
    /// <returns></returns>
    IEnumerator LoadNextScene(SceneType nextLoadSceneName) 
    {
    // シーン名を指定する引数には、enum である SceneType の列挙子を、ToString メソッドを使って string 型へキャストして利用
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextLoadSceneName.ToString());

    // シーンが完全にロードされるまで待機
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}