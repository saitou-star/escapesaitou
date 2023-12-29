using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainStage : MonoBehaviour
{
     [SerializeField]
    private Vector3 targetPosition = new Vector3(0f, 0f, 0f);

    // メインシーンに戻る
    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainStage");
    }

    // 特定の位置に戻る
    public void ReturnToSpecificLocation()
    {
        SceneManager.LoadScene("MainStage");

        // インスペクタービューで指定された位置にプレイヤーを配置
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = targetPosition;
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }

   
}
