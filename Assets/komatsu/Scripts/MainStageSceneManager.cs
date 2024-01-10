using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStageSceneManager : MonoBehaviour
{
    public static MainStageSceneManager Instance;
    public Vector3 lastPlayerPosition;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
