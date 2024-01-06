using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerSceneChanger : MonoBehaviour
{
    private bool touchingClearPanel = false;

    [SerializeField]
    private AudioClip SceneChangeSound;

    [SerializeField]
    private float seVolume = 0.8f; // SEの音量（0.0から1.0）

    private Vector3 playerLastPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingClearPanel = true;
            playerLastPosition = other.transform.position;

            // 佐々木案
            MainStageSceneManager.Instance.lastPlayerPosition = playerLastPosition;

            // PenguinManagerにデータを保存
            PenguinManager.Instance.SavePenguinData(other.gameObject, playerLastPosition);
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
        AudioSource SceneChangeAudioSource = GetComponent<AudioSource>();
        SceneChangeAudioSource.volume = seVolume;
        SceneChangeAudioSource.Play();

        yield return new WaitForSeconds(0.5f);

        Debug.Log("新しいシーンに切り替えます。");
        SceneManager.LoadScene("FlowerScene");
    }
}


