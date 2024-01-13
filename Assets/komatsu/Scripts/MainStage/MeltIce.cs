using UnityEngine;

public class MeltIce : MonoBehaviour
{
    int completeNum = 0;

    [SerializeField]
    private AudioSource MeltIceSE;
    [SerializeField]
    private GameObject IceHintPanel;

    private GameObject Ice;

    [SerializeField]
    private int keyItemId; // キーアイテムのID

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                Ice = hit.collider.gameObject;

                // クリックされたオブジェクトのタグが"IceBloc"で、かつ選択されたアイテムが正しい場合に消す
                Item selectedItem = ItemBox.instance.GetSelectedItem();
                if (Ice.CompareTag("IceBloc") && selectedItem != null && selectedItem.itemID == keyItemId)
                {
                    OnUseItem(selectedItem); // 選択されたアイテムを引数として渡す
                }
            }
        }
    }

    public void OnUseItem(Item selected)
    {
        Debug.Log("氷が溶けた！");
        DestroyIce();
        // 選択されたアイテムを削除
        ItemBox.instance.RemoveItem(selected);
    }

    public void OnFailed()
    {
        IceHintPanel.SetActive(true);
        Debug.Log("氷を溶かすことができない。");
    }

    public void DestroyIce()
    {
        MeltIceSE.Play(); // AudioSourceのPlayメソッドでSEを再生
        Destroy(Ice);
    }
}

