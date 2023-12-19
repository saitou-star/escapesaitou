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
        // AudioSource コンポーネントがアタッチされているか確認
        if (successSE == null)
        {
            // AudioSource がアタッチされていない場合は警告を表示
            Debug.LogWarning("AudioSourceがアタッチされていません.");
        }

        if (failureSE == null)
        {
            // AudioSource がアタッチされていない場合は警告を表示
            Debug.LogWarning("AudioSourceがアタッチされていません.");
        }
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
            if (passKeyCorrect())
            {
                Debug.Log("Correct order entered! Displaying success UI.");
                // 成功UIを表示する
                UpArrow.SetActive(true);
                // 成功時のSEを再生
                if (successSE != null)
                {
                    successSE.Play();
                }
                
            }
            else
            {
                Debug.Log("Incorrect order entered! Resetting input.");

                // 失敗時のSEを再生
                if (failureSE != null)
                {
                    failureSE.Play();
                }
            }

            // 正誤判定後にcurrentIndexと入力をリセット
            currentIndex = 0;
            for (int i = 0; i < inputPassKey.Length; i++)
            {
                inputPassKey[i] = 0;
            }
        }
    }

    private bool passKeyCorrect()
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
}
