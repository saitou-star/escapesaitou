using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MajoMap2 : MonoBehaviour
{
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // startPosition = transform.position;
        // transform.position = new Vector3(4, 6, -33);



    }

    // Update is called once per frame
    void Update()
    {
        // Transform.transform = this.transform;


    }
    void ChangeScene()
    {
        OnEnable();
        SavePlayerPosition();
        transform.position = startPosition;
        SceneManager.LoadScene("Can");

        // this.transform.position = new Vector3(0, 0, 3);
    }

    private void SavePlayerPosition()
    {
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += RestorePlayerPosition;
    }

    private void RestorePlayerPosition(Scene scene, LoadSceneMode mode)
    {
        transform.position = startPosition;
    }
}
