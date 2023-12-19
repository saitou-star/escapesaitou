using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSceneMove : MonoBehaviour
{
    public void OnHelpButtonClick()
    {
        // セーブ画面に切り替える
        SceneStateManager.instance.PreparateNextScene(SceneType.HelpScene);
    }
}
