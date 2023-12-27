using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMove : MonoBehaviour
{
    public void OnLoadButtonClick()
    {
        ItemBox.instance.itemBoxPanel.SetActive(false);
        SceneManager.LoadScene("LoadScene");
    }
}
