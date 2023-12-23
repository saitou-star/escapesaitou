using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageChangeOnClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject newImagePrefab; // 新しい画像のPrefabをInspectorで設定

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeImage();
    }

    void ChangeImage()
    {
        Vector3 clickPosition = Input.mousePosition;
        clickPosition.z = 10f; // 画像が表示される深さを設定

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

        GameObject newImage = Instantiate(newImagePrefab, worldPosition, Quaternion.identity);
        newImage.transform.SetParent(transform.parent); // 新しい画像をPanelの親に設定
    }
}
