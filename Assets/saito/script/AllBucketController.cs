using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBucketController : MonoBehaviour
{
    bool pushEnter;
    // 配列＝水のオブジェクトを入れ管理、int型は水オブジェクトの表示非表示の計算のため
    GameObject[] Bucket_Ten;
    GameObject[] Bucket_Seven;
    GameObject[] Bucket_Three;
    int num10;
    int num7;
    int num3;

    // 当たり判定に使うBoxcollider型の変数用意
    BoxCollider bucket10Collider;
    BoxCollider bucket07Collider;
    BoxCollider bucket03Collider;


    void Start()
    {
        // 10，7，3の水を配列に。
        Bucket_Ten = new GameObject[]{
            GameObject.Find("WaterOne_ten"),
            GameObject.Find("WaterTwo_ten"),
            GameObject.Find("WaterThree_ten"),
            GameObject.Find("WaterFour_ten"),
            GameObject.Find("WaterFive_ten"),
            GameObject.Find("WaterSix_ten"),
            GameObject.Find("WaterSeven_ten"),
            GameObject.Find("WaterEight_ten"),
            GameObject.Find("WaterNine_ten"),
            GameObject.Find("WaterTen_ten")
        };

        Bucket_Seven = new GameObject[]{
            GameObject.Find("WaterOne_seven"),
            GameObject.Find("WaterTwo_seven"),
            GameObject.Find("WaterThree_seven"),
            GameObject.Find("WaterFour_seven"),
            GameObject.Find("WaterFive_seven"),
            GameObject.Find("WaterSix_seven"),
            GameObject.Find("WaterSeven_seven")
        };

        Bucket_Three = new GameObject[]{
            GameObject.Find("WaterOne_three"),
            GameObject.Find("WaterTwo_three"),
            GameObject.Find("WaterThree_three")
        };

        // 配列作成時、非表示だと代入出来ない為、全ての水オブジェクトを表示させている。
        // 下記は初回は表示されている配列内の全てのオブジェクトから、表示する必要のないオブジェクトを非表示に変更
        SetObjectsActive(Bucket_Seven, false);
        SetObjectsActive(Bucket_Three, false);
    }

    void Update()
    {
        // enterを押されたら,をpushEnterに代入
        pushEnter = Input.GetKeyDown(KeyCode.Return);
    }


    private void OnTriggerStay(Collider other)
    {
        num10 = GetActiveCount(Bucket_Ten);
        num7 = GetActiveCount(Bucket_Seven);
        num3 = GetActiveCount(Bucket_Three);

        // 親がnullではなく、名前がpenguinで、pushEnter(Input.GetKeyDown("Return"))がtrueならば
        if (transform.parent != null && transform.parent.name == "Penguin" && pushEnter)
        {
            Debug.Log("trigger");
            // 当たり判定用にオブジェクトのboxcolliderを取得
            bucket10Collider = GameObject.Find("Bucket_10").GetComponent<BoxCollider>();
            bucket07Collider = GameObject.Find("Bucket_07").GetComponent<BoxCollider>();
            bucket03Collider = GameObject.Find("Bucket_03").GetComponent<BoxCollider>();

            // バケツ間での水の受け渡し。int~の数値の移動
            CheckCollision("Bucket_10", bucket07Collider, Bucket_Ten, Bucket_Seven, 7);
            CheckCollision("Bucket_10", bucket03Collider, Bucket_Ten, Bucket_Three, 3);
            CheckCollision("Bucket_07", bucket10Collider, Bucket_Seven, Bucket_Ten, 10);
            CheckCollision("Bucket_07", bucket03Collider, Bucket_Seven, Bucket_Three, 3);
            CheckCollision("Bucket_03", bucket10Collider, Bucket_Three, Bucket_Ten, 10);
            CheckCollision("Bucket_03", bucket07Collider, Bucket_Three, Bucket_Seven, 7);
        }
    }


    void SetObjectsActive(GameObject[] objects, bool active)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(active);
        }
    }


    int GetActiveCount(GameObject[] objects)
    {
        int count = 0;
        for (int i = objects.Length - 1; i >= 0; i--)
        {
            if (objects[i] != null && objects[i].activeSelf)
            {
                count = i + 1;
                break;
            }
        }
        return count;
    }

    void CheckCollision(string bucketName, BoxCollider otherCollider, GameObject[] buckets, GameObject[] targetBuckets, int targetCount)
    {
        Debug.Log("check");
        if (gameObject.name == bucketName && Physics.CheckBox(transform.position, otherCollider.size))
        {
            int diff = targetCount - GetActiveCount(targetBuckets);
            if (diff > 0)
            {
                int y = diff;
                for (int i = (GetActiveCount(buckets) - 1); y >= 0; y--)
                {
                    if (i >= 0)
                    {
                        buckets[i].SetActive(false);
                        i -= 1;

                        if ((targetCount + y) <= targetCount)
                        {
                            targetBuckets[targetCount - 1 - y].SetActive(true);
                            // for (int x = (targetCount - 1 - y); x >= 0; x--)
                            // {
                            //     targetBuckets[x].SetActive(true);
                            // }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}