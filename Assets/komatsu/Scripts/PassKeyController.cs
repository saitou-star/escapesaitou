using UnityEngine;

public class PassKeyController : MonoBehaviour
{
    public int[] ansPassKey = { 3, 9, 1, 2 }; // 正しい順序
    private int[] inputPassKey = new int[4]; // ユーザーがクリックした順序
    private int currentIndex = 0; // 現在のインデックス

    [SerializeField]
    private GameObject UpArrow; // 成功時に表示するUI
    [SerializeField]
    private AudioSource successSE; // 成功時のSE
    [SerializeField]
    private AudioSource failureSE; // 失敗時のSE

    private void Start()
    {
    }

    public void OnPanelClick(int digit)
    {
        Debug.Log("Panel Clicked! Digit: " + digit);

        // 入力された数字を配列に保存
        inputPassKey[currentIndex] = digit;
        currentIndex++;

        // 配列が満たされたら正誤判定
        if (currentIndex == ansPassKey.Length)
        {
            if (IsPassKeyCorrect())
            {
                Debug.Log("Correct order entered! Displaying success UI.");
                UpArrow.SetActive(true);
                // 成功時のSEを再生
                if (successSE != null)
                    successSE.Play();
            }
            else
            {
                Debug.Log("Incorrect order entered! Resetting input.");
                ResetInput();
                // 失敗時のSEを再生
                if (failureSE != null)
                    failureSE.Play();
                // 失敗した場合も currentIndex と inputPassKey をリセット
                currentIndex = 0;
                for (int i = 0; i < inputPassKey.Length; i++)
                {
                    inputPassKey[i] = 0;
                }
            }
        }
    }

    private bool IsPassKeyCorrect()
    {
        // 入力されたパスキーが正しいかどうかをチェック
        for (int i = 0; i < ansPassKey.Length; i++)
        {
            if (inputPassKey[i] != ansPassKey[i])
            {
                return false;
            }
        }
        return true;
    }

    private void ResetInput()
    {
        // 入力をリセット
        currentIndex = 0;
        for (int i = 0; i < inputPassKey.Length; i++)
        {
            inputPassKey[i] = 0;
        }
    }
}
