using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene_flour : MonoBehaviour
{
    [SerializeField] private AudioClip doorSound; // ドアが開く音のファイル
    [SerializeField] private float seVolume = 0.8f; // SEの音量（0.0から1.0）

    private AudioSource doorAudioSource;

    private void Start()
    {
        // AudioSourceコンポーネントを取得
        doorAudioSource = GetComponent<AudioSource>();

        // UIアイコンのButtonコンポーネントを取得
        Button uiButton = GetComponent<Button>();
        if (uiButton != null)
        {
            // クリック時の処理を登録
            uiButton.onClick.AddListener(OpenDoorAndSwitchScene);
        }
    }

    public void OpenDoorAndSwitchScene()
    {
        // AudioSourceがnullでないことを確認
        if (doorAudioSource != null)
        {
            // SEの音量を設定
            doorAudioSource.volume = seVolume;

            // SEの再生
            doorAudioSource.Play();
        }

        Debug.Log("ドアが開きます...");

        Debug.Log("ドアが開きました。新しいシーンに切り替えます.");

        // 新しいシーンに切り替える
        SceneManager.LoadScene("FrowerScene");
    }
}
