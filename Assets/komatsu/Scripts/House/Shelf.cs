using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public void Open(GameObject shelfOpen)
    {
        bool isOpen = shelfOpen.activeSelf;
        shelfOpen.SetActive(!isOpen);
        Debug.Log("Openした");
    }
}
