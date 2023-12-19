using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromHelpScene : MonoBehaviour
{
void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        // 前のSceneに戻る
        SceneStateManager.instance.PreparateNextScene(SceneType.UI);//前のSceneの名前
    }
}
}