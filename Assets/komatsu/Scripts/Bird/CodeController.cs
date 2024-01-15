using UnityEngine;

public class CodeController : MonoBehaviour
{
    [SerializeField]
    int[] Answer = { };

    [SerializeField]
    CodePanel[] codePanels = default;

    [SerializeField]
    private GameObject Panel;

    [SerializeField]
    private AudioSource successSE;

    [SerializeField]
    private AudioSource failureSE;

    [SerializeField]
    private GameObject FencePanel;

    public bool fenceCodePanel = false;


    public void OnClickButton()
    {
        Debug.Log("ボタン検知");
        if (CheckClear())
        {
            Debug.Log("Clear");

            // 正解の場合、他のパネルを非アクティブにする
            ClosePanel();
            // 成功時のSEを再生
            if (successSE != null)
            {
                successSE.Play();
            }

            fenceCodePanel = true;
            // セーブデータにクリアフラグを設定
            GameSaveData.Instance.SetGameFlag("SeaCodeClear", 1);
        }
    }

    bool CheckClear()
    {
        for (int i = 0; i < codePanels.Length; i++)
        {
            if (codePanels[i].number != Answer[i])
            {
                Debug.Log($"Panel {i + 1} does not match. Expected: {Answer[i]}, Actual: {codePanels[i].number}");
                // 失敗時のSEを再生
                if (failureSE != null)
                {
                    failureSE.Play();
                }
                return false;
            }
        }
        return true;
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
}
