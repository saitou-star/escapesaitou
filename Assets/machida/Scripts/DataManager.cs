using UnityEngine;

public class DataManager : MonoBehaviour
{
    private Transform playerTransform;
    private Slot boxScript;
    private void Start()
    {
        GameObject playerObject = GameObject.Find("Penguin");
        GameObject boxObject = GameObject.Find("Slot");
        boxScript = boxObject.GetComponent<Slot>();

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
        
        // boxScript.slot.ToList().ForEach(System.Console.WriteLine);
        
    }
}