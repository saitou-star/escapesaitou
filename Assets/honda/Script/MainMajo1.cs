using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMajo1 : MonoBehaviour
{
    private Vector3 startPosition;

    public Transform penguin;

    private Transform _initialTransform;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        // _initialTransform = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangeScene()
    {
        OnEnable();

        SavePlayerPosition();
        SceneManager.sceneLoaded += GameSceneLoaded;
        // transform.position = new Vector3(4, 6, -33);
        SceneManager.LoadScene("Majo");

        // gameObject.transform.position = _initialTransform.position;
        // this.transform.position = new Vector3(4, 6, -33);
    }
    private void SavePlayerPosition()
    {
        GameManager1.instance.SetLastPos(penguin.position);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += RestorePlayerPosition;
    }

    private void RestorePlayerPosition(Scene scene, LoadSceneMode mode)
    {
        transform.position = startPosition;
    }
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        var gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager1>();

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

}
