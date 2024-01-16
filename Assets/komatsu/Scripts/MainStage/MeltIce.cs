using UnityEngine;

public class MeltIce : MonoBehaviour
{
    [SerializeField]
    private AudioSource MeltIceSE;
    [SerializeField]
    private GameObject IceHintPanel;

    private GameObject Ice;

    [SerializeField]
    private int keyItemId; // キーアイテムのID

    [SerializeField]
    private float maxClickDistance = 2f; // クリックできる最大距離


 void Start()
     {
        // セーブデータから状態を復帰させる
        int meltIceFlag = GameSaveData.Instance.GetGameFlag("MeltIce");

      if (meltIceFlag == 1)
        {
            // 氷がまだ存在している場合だけ破壊する
            Ice = GameObject.FindGameObjectWithTag("IceBloc");
            if (Ice != null)
            {
                DestroyIce();
            }
        }
    }

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
                if (Ice.CompareTag("IceBloc") && selectedItem != null && selectedItem.itemID == keyItemId &&
                    Vector3.Distance(Ice.transform.position, transform.position) <= maxClickDistance)
                {
                    GameSaveData.Instance.SetGameFlag("MeltIce", 1);
                    OnUseItem(selectedItem); // 選択されたアイテムを引数として渡す
                    
                }
                else if (Ice.CompareTag("IceBloc") && (selectedItem == null || selectedItem.itemID != keyItemId))
                {
                    OnFailed();
                }
            }
        }
    }



    public void OnUseItem(Item selected)
    {
        Debug.Log("氷が溶けた！");
        MeltIceSE.Play(); // AudioSourceのPlayメソッドでSEを再生
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
        Destroy(Ice);
    }
}

