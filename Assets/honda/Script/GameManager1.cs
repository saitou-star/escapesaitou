using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;
    public Vector3 lastPos;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetLastPos()
    {
        return this.lastPos;
    }

    public void SetLastPos(Vector3 pos)
    {
        this.lastPos = pos += new Vector3(0, 0, -10.0f);
    }
}
