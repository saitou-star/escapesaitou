using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceController : MonoBehaviour
{
    void Start()
    {
        // セーブデータからクリア状態を読み込む
        int seaCodeClear = GameSaveData.Instance.GetGameFlag("SeaCodeClear");

        if (seaCodeClear == 1)
        {
            Debug.Log("seaCode");

            Debug.Log("FencePanel");
            // Fenceが存在する場合、非アクティブにする
            gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
