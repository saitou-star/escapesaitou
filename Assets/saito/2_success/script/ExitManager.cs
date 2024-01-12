using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitManager : MonoBehaviour
{
    public GameObject player;  // 接触してきたオブジェクト
    public GameObject window;  // 表示・非表示対象となるcanvas,初期で非アクティブ化する
    private PenguinManager penguinManager;


    void Start()
    {
        window.gameObject.SetActive(false);
        penguinManager = FindObjectOfType<PenguinManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            window.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Y))
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
            else if (Input.GetKeyDown(KeyCode.N))
            {
                window.gameObject.SetActive(false);
                SceneManager.LoadScene("Second");
            }
        }
    }
}
