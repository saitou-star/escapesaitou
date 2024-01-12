using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HelpManager : MonoBehaviour
{
    public GameObject player;
    private PenguinManager penguinManager;

    void Start()
    {
        penguinManager = FindObjectOfType<PenguinManager>();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject == player && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("MainStage");

            if (penguinManager != null)
            {
                GameObject penguinPrefab = penguinManager.GetPenguinPrefab();
                Vector3 penguinPosition = penguinManager.GetPenguinPosition();

                if (penguinPrefab != null)
                {
                    GameObject penguin = Instantiate(penguinPrefab);
                    penguin.transform.position = penguinPosition;
                }
            }
        }
        else if (collider.gameObject == player && Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("Second");
        }
    }
}
