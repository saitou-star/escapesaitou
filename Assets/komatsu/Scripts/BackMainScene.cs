using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMainScene : MonoBehaviour
{
    public void SwitchScene()
    {
        Debug.Log("新しいシーンに切り替えます.");

        // 新しいシーンに切り替える
        SceneManager.LoadScene("stage01");
    }
}
