using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnToMainStage : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPosition = new Vector3(0f, 0f, 0f);

    private FlowerSceneChanger flowerSceneChanger;

    private void Start()
    {
        flowerSceneChanger = FindObjectOfType<FlowerSceneChanger>();
        if (flowerSceneChanger == null)
        {
            Debug.LogError("FlowerSceneChanger not found!");
        }
    }

    // メインシーンに戻る
    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainStage");
    }

    // 特定の位置に戻る
    public void ReturnToSpecificLocation()
    {
        SceneManager.LoadScene("MainStage");

        // FlowerSceneChanger が見つかっていれば、その座標を使用
        if (flowerSceneChanger != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = flowerSceneChanger.PlayerLastPosition;
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }
    }
}