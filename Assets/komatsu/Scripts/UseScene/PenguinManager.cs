using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinManager : MonoBehaviour
{
    public static PenguinManager Instance { get; private set; }

    [SerializeField]
    private Transform playerTransform; // インスペクターで指定するプレイヤーのTransform

    [SerializeField]
    private GameObject penguinPrefab;
    private Vector3 penguinPosition;

    private void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
        if (MainStageSceneManager.Instance.lastPlayerPosition != Vector3.zero)
        {
            playerTransform.position = MainStageSceneManager.Instance.lastPlayerPosition;
        }

    }

    public void SavePenguinData(GameObject penguinObject, Vector3 position)
    {
        penguinPrefab = penguinObject;
        penguinPosition = position;
    }

    public GameObject GetPenguinPrefab()
    {
        return penguinPrefab;
    }

    public Vector3 GetPenguinPosition()
    {
        return penguinPosition;
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
}
