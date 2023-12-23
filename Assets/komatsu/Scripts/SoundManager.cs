using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip successSE;
    [SerializeField]
    private AudioClip failureSE;
    [SerializeField]
    private AudioClip getItemSE;

    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceの取得
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySuccessSound()
    {
        // 成功時のサウンドを再生
        audioSource.clip = successSE;
        audioSource.Play();
    }

    public void PlayFailureSound()
    {
        // 失敗時のサウンドを再生
        audioSource.clip = failureSE;
        audioSource.Play();
    }

    public void PlayGetItemSound()
    {
        // 失敗時のサウンドを再生
        audioSource.clip = getItemSE;
        audioSource.Play();
    }
}
