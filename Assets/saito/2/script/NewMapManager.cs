using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapManager : MonoBehaviour
{
    public Transform blockParent;
    public GameObject blockPrefab_Ice; // 氷ブロック
    public GameObject blockPrefab_Iceberg; // 氷山ブロック

    public const int MAP_WIDTH = 30;
    public const int MAP_HEIGHT = 30;
    private const int MAX_ICEBERGS = 15;

    private List<GameObject> icebergs = new List<GameObject>();

    private void Start()
    {
        GenerateFullIceMap();
        StartCoroutine(SpawnIcebergs());
    }

    private void GenerateFullIceMap()
    {
        for (int i = 0; i < MAP_WIDTH; i++)
        {
            for (int j = 0; j < MAP_HEIGHT; j++)
            {
                Vector3 pos = new Vector3(i - MAP_WIDTH / 2, 0, j - MAP_HEIGHT / 2);
                GameObject iceBlock = Instantiate(blockPrefab_Ice, pos, Quaternion.identity, blockParent);
            }
        }
    }

    private IEnumerator SpawnIcebergs()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (icebergs.Count < MAX_ICEBERGS)
            {
                Vector3 icebergPos = new Vector3(Random.Range(-MAP_WIDTH / 2, MAP_WIDTH / 2), 0, Random.Range(-MAP_HEIGHT / 2, MAP_HEIGHT / 2));
                GameObject iceberg = Instantiate(blockPrefab_Iceberg, icebergPos, Quaternion.identity, blockParent);
                icebergs.Add(iceberg);
            }
            else
            {
                DestroyOldestIceberg();
            }
        }
    }

    private void DestroyOldestIceberg()
    {
        if (icebergs.Count > 0)
        {
            Destroy(icebergs[0]);
            icebergs.RemoveAt(0);
        }
    }
}