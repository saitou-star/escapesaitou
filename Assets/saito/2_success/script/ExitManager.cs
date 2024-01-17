// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class ExitManager : MonoBehaviour
// {
//     public GameObject player;
//     private PenguinManager penguinManager;

//     void Start()
//     {
//         penguinManager = FindObjectOfType<PenguinManager>();
//     }

//     void OnTriggerStay(Collider collider)
//     {
//         if (collider.gameObject == player)
//         {
//             HandleInput();
//         }
//     }

//     void HandleInput()
//     {
//         if (Input.GetKeyDown(KeyCode.Y))
//         {
//             HandleYesInput();
//         }
//         else if (Input.GetKeyDown(KeyCode.N))
//         {
//             HandleNoInput();
//         }
//     }

//     void HandleYesInput()
//     {
//         SceneManager.LoadScene("MainStage");

//         if (penguinManager != null)
//         {
//             GameObject penguinPrefab = penguinManager.GetPenguinPrefab();
//             Vector3 penguinPosition = penguinManager.GetPenguinPosition();

//             if (penguinPrefab != null)
//             {
//                 GameObject penguin = Instantiate(penguinPrefab);
//                 penguin.transform.position = penguinPosition;
//             }
//         }
//     }

//     void HandleNoInput()
//     {
//         SceneManager.LoadScene("Second");
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject player;
    private PenguinManager penguinManager;
    [SerializeField]
    private GameObject exitPanel;

    private bool inputProcessed = false;

    void Start()
    {
        penguinManager = FindObjectOfType<PenguinManager>();
        exitPanel.SetActive(false);
        inputProcessed = false;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject == player && !inputProcessed)
        {
            exitPanel.SetActive(true);

            // コライダーに当たっている間で、かつまだ入力が処理されていない場合
            if (Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.N))
            {
                HandleInput();
                inputProcessed = true; // 入力が処理されたことをマーク
            }
        }
        else if (collider.gameObject != player)
        {
            exitPanel.SetActive(false);
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            HandleYesInput();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            HandleNoInput();
        }
    }

    void HandleYesInput()
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

    void HandleNoInput()
    {
        SceneManager.LoadScene("Second");
    }
}


