using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class riyuu : MonoBehaviour
{
    public Fungus.Flowchart flowchart = null;
    public String sendMessage = "";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            flowchart.SendFungusMessage(sendMessage);
        }
    }
}
