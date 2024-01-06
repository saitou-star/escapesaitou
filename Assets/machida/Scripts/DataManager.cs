using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    private Transform playerTransform;
    private ItemBox boxScript;
    public Vector3 playerPosition;
    private void Awake()
    {
        // プレイヤー座標の為のオブジェクト取得
        GameObject playerObject = GameObject.Find("Penguin");
        // アイテムボックスの為のオブジェクト取得
        GameObject boxObject = GameObject.Find("ItemBoxCanvas");
        boxScript = boxObject.GetComponent<ItemBox>();

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    private void Update()
    {
        // Debug.Log(playerTransform.position);

        // boxScript.Slot.ToList().ForEach(System.Console.WriteLine);

    }
}