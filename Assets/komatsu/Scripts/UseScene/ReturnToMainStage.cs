using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnToMainStage : MonoBehaviour
{
    private PenguinManager penguinManager;

    private void Start()
    {
        penguinManager = FindObjectOfType<PenguinManager>();
        if (penguinManager == null)
        {
            Debug.LogError("PenguinManager not found!");
        }
    }

    // 特定の位置に戻る
    public void ReturnToSpecificLocation()
    {
        SceneManager.LoadScene("MainStage");

        if (penguinManager != null)
        {
            GameObject penguinPrefab = penguinManager.GetPenguinPrefab();
            Vector3 penguinPosition = penguinManager.GetPenguinPosition();

            if (penguinPrefab != null)
            {
                GameObject penguin = Instantiate(penguinPrefab);
                penguin.transform.position = penguinPosition;
            }
            else
            {
                Debug.LogError("Penguin prefab not found!");
            }
        }
    }
    public void OnLoadButtonClicked()
    {
        SceneManager.LoadScene("MainStage");
    }

}
