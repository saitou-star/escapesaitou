using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitManager : MonoBehaviour
{
    public GameObject player;  // 接触してきたオブジェクト
    public Canvas window;  // 表示・非表示対象となるcanvas

    void Start()
    {
        // 初期で非アクティブ化
        window.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player)
        {
            window.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Y))
            {

            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                window.gameObject.SetActive(false);
                SceneManager.LoadScene("Second");

            }


        }
    }
}
