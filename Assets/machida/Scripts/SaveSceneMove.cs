using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSceneMove : MonoBehaviour
{
    public void OnSaveButtonClick()
    {
        ItemBox.instance.itemBoxPanel.SetActive(false);
        SceneManager.LoadScene("SaveScene");
    }
}
