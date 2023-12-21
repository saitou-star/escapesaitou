using UnityEngine;
using UnityEngine.UI;

public class ZoomPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject zoomPanel;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private Text itemTypeText;

    void Start()
    {
        HideZoomPanel();
    }

    public void OnClickZoom(Item item)
    {
        // アイテムの情報を表示
        itemImage.sprite = item.sprite;
        itemTypeText.text = item.type.ToString();

        // Zoomパネルを表示
        zoomPanel.SetActive(true);
    }

    public void HideZoomPanel()
    {
        // Zoomパネルを非表示
        zoomPanel.SetActive(false);
    }
}
