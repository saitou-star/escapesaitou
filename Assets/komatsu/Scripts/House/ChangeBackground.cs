using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField]
    private Sprite backgroundImage; // 最初の背景
    [SerializeField]
    private Sprite newBackgroundImage; // 新しい背景

    void Start()
    {
        // 初期の背景画像を設定
        if (backgroundImage != null)
        {
            // 事前にインポートした画像やSpriteを使用する場合
            // backgroundImage.sprite = YourInitialSprite;

            // または、画像のパスを指定して設定する場合
            // backgroundImage.sprite = Resources.Load<Sprite>("YourImagePath");
        }
    }

    public void OnButtonClick()
    {
        // ボタンがクリックされたときの処理
        if (backgroundImage != null && newBackgroundImage != null)
        {
            // 背景画像を新しい画像に変更
            backgroundImage = newBackgroundImage;
        }
    }
}
