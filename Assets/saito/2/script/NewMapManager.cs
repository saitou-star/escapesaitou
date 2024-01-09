using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapManager : MonoBehaviour
{
    public Transform blockParent; // インスペクター上で設定しなくても可
    public GameObject blockPrefab_Ice;
    public GameObject randamWall01;    // ランダム壁01~03
    public GameObject randamWall02;
    public GameObject randamWall03;
    public GameObject blockPrefab_Iceberg;

    public const int MAP_WIDTH = 20;
    public const int MAP_HEIGHT = 20;
    private const int MAX_ICEBERGS = 16;

    // 壁の生成確率（合計が1になるように設定）
    public float probability_LeftWall = 0.0f;
    public float probability_MiddleWall = 0.0f;
    public float probability_RightWall = 1.0f;

    private List<GameObject> icebergs = new List<GameObject>();

    private void Start()
    {
        GenerateFullIceMap();
        GenerateInitialIcebergs();
        StartCoroutine(SpawnIcebergs());
    }

    private void GenerateFullIceMap()
    {
        for (int i = -1; i <= MAP_WIDTH; i++)
        {
            for (int j = 0; j < MAP_HEIGHT; j++)
            {
                // エッジの位置かどうかをチェック
                if (i == -1)
                {
                    // 左端の場合
                    Vector3 wallPos = new Vector3(i - MAP_WIDTH / 2, 0.6f, j - MAP_HEIGHT / 2);
                    GameObject selectedWallBlock = GetRandomWallPrefab();
                    GameObject wallObject = Instantiate(selectedWallBlock, wallPos, Quaternion.Euler(0, 90, 0), blockParent);
                    wallObject.transform.localScale *= 1.3f;  // 壁を1.3倍する
                }
                else if (i == MAP_WIDTH)
                {
                    // 右端の場合
                    Vector3 wallPos = new Vector3(i - MAP_WIDTH / 2, 0.6f, j - MAP_HEIGHT / 2);
                    GameObject selectedWallBlock = GetRandomWallPrefab();
                    GameObject wallObject = Instantiate(selectedWallBlock, wallPos, Quaternion.Euler(0, -90, 0), blockParent);
                    wallObject.transform.localScale *= 1.3f;  // 壁を1.3倍する
                }
                else
                {
                    // 通常の氷ブロック
                    Vector3 pos = new Vector3(i - MAP_WIDTH / 2, 0, j - MAP_HEIGHT / 2);
                    GameObject iceBlock = Instantiate(blockPrefab_Ice, pos, Quaternion.identity, blockParent);
                }
            }
        }
    }

    private GameObject GetRandomWallPrefab()
    {
        float randomValue = Random.value;
        if (randomValue < probability_LeftWall)
        {
            return randamWall01;
        }
        else if (randomValue < probability_LeftWall + probability_MiddleWall)
        {
            return randamWall02;
        }
        else
        {
            return randamWall03;
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
        Vector3 icebergPos = new Vector3(Random.Range(-MAP_WIDTH / 2, MAP_WIDTH / 2), 0.6f, Random.Range(-MAP_HEIGHT / 2, MAP_HEIGHT / 2));
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