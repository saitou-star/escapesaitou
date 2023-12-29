using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   
    private bool touchingClearPanel = false;

    [SerializeField] 
    private AudioClip SceneChangeSound; 

    [SerializeField] 
    private float seVolume = 0.8f; // SEの音量（0.0から1.0）

    [SerializeField]
    private string changeScene = "";



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingClearPanel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           touchingClearPanel = false;
        }
    }

    private void Update()
    {
        if (touchingClearPanel && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OpenDoorAndSwitchScene());
        }
    }

    private IEnumerator OpenDoorAndSwitchScene()
    {
        // SEの再生
        AudioSource SceneChangeAudioSource = GetComponent<AudioSource>();


        // SEの音量を設定
        SceneChangeAudioSource.volume = seVolume;

        // SEの再生
        SceneChangeAudioSource.Play();

        Debug.Log("ドアが開きます...");

        // ここでドアが開くアニメーションを再生する
        yield return new WaitForSeconds(2f); // 例: アニメーションの再生時間が2秒と仮定

        Debug.Log("ドアが開きました。新しいシーンに切り替えます。");

        // 新しいシーンに切り替える
        SceneManager.LoadScene(changeScene);
    }
}


