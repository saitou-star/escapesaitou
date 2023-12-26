using UnityEngine;

public class DataManager : MonoBehaviour
{
    private Transform playerTransform;
    // ItemBox script;

    private void Start()
    {
        GameObject playerObject = GameObject.Find("Penguin");
        // GameObject slotObject = GameObject.Find("ItemBox");
        // script = slotObject.GetComponent<ItemBox>();

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

        Debug.Log(playerTransform.position);
        // Debug.Log(script.items);
    }
}