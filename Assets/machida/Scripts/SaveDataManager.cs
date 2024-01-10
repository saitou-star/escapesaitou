using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject itembox;
    // Start is called before the first frame update
    public void GoSave()
    {
        // 座標セーブ
        PlayerPrefs.SetFloat("CharacterX", player.transform.position.x);
        PlayerPrefs.SetFloat("CharacterY", player.transform.position.y);
        PlayerPrefs.SetFloat("CharacterZ", player.transform.position.z);
        PlayerPrefs.Save();
    }
    public void GoLoad()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("CharacterX",0),PlayerPrefs.GetFloat("CharacterY",0),PlayerPrefs.GetFloat("CharacterZ",0));
    }
}