using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnScene : MonoBehaviour
{
    // Start is called before the first frame update
void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        // 前のSceneに戻る
        SceneStateManager.instance.PreparateNextScene(SceneType.UI);//前のSceneの名前
    }
}
}
