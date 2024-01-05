using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapManager : MonoBehaviour
{
    public Transform blockParent;               // 生成されたブロックをまとめるための親オブジェクトのTransform
    public GameObject blockPrefab_Ice;          // 氷ブロックのプレハブ
    public GameObject blockPrefab_Iceberg;      // 氷山ブロックのプレハブ

    public const int MAP_WIDTH = 30;            // マップの幅
    public const int MAP_HEIGHT = 30;           // マップの高さ
    private const int MAX_ICEBERGS = 10;        // 同時に存在できる最大氷山数

    private List<GameObject> icebergs = new List<GameObject>();  // 生成された氷山ブロックを格納するリスト

    private void Start()
    {
        GenerateFullIceMap();        // マップ上に氷ブロックを生成
        GenerateInitialIcebergs();   // 最初に氷山を生成
        StartCoroutine(SpawnIcebergs());  // 定期的に氷山ブロックをスポーン
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

    private void GenerateInitialIcebergs()
    {
        for (int i = 0; i < MAX_ICEBERGS; i++)
        {
            SpawnIceberg();
        }
    }

    private void SpawnIceberg()
    {
        Vector3 icebergPos = new Vector3(Random.Range(-MAP_WIDTH / 2, MAP_WIDTH / 2), 1, Random.Range(-MAP_HEIGHT / 2, MAP_HEIGHT / 2));
        GameObject iceberg = Instantiate(blockPrefab_Iceberg, icebergPos, Quaternion.identity, blockParent);
        icebergs.Add(iceberg);
    }

    private IEnumerator SpawnIcebergs()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);   // 5秒ごとに以下の処理を実行

            // 古い氷山を削除
            DestroyOldestIcebergs();

            // 新たにランダムな位置に氷山を生成
            for (int i = 0; i < MAX_ICEBERGS; i++)
            {
                SpawnIceberg();
            }
        }
    }

    private void DestroyOldestIcebergs()
    {
        // 最も古い氷山を削除
        int countToRemove = Mathf.Max(0, icebergs.Count - MAX_ICEBERGS);
        for (int i = 0; i < countToRemove; i++)
        {
            Destroy(icebergs[i]);
        }
        icebergs.RemoveRange(0, countToRemove);
    }
}