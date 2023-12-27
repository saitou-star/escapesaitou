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
        foreach (GameObject obj in Bucket_Seven)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in Bucket_Three)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        // enterを押されたら,をpushEnterに代入
        pushEnter = Input.GetKeyDown("Return");
    }

    private void OnTriggerStay(Collider other)
    {
        // for文を使い各int型のnum~のtrue(表示されているオブジェクトの位置)を確認。
        for (int i = 9; i >= 0; i--)
        {
            if (Bucket_Ten[i] == null)
            {
                continue;
            }
            else if (Bucket_Ten[i] == true)
            {
                num10 = i;
            }
            else if (Bucket_Ten[0] == null)
            {
                num10 = 0;
            }
        }

        for (int i = 6; i >= 0; i--)
        {
            if (Bucket_Seven[i] == null)
            {
                continue;
            }
            else if (Bucket_Seven[i] == true)
            {
                num7 = i;
            }
            else
            {
                num7 = 0;
            }
        }

        for (int i = 2; i >= 0; i--)
        {
            if (Bucket_Seven[i] == null)
            {
                continue;
            }
            else if (Bucket_Three[i] == true)
            {
                num3 = i;
            }
            else
            {
                num3 = 0;
            }
        }

        // 親がnullではなく、名前がpenguinで、pushEnter(Input.GetKeyDown("Return"))がtrueならば
        if (transform.parent != null && transform.parent.name == "penguin" && pushEnter)
        {
            // 当たり判定用にオブジェクトのboxcolliderを取得
            bucket10Collider = GameObject.Find("Bucket_10").GetComponent<BoxCollider>();
            bucket07Collider = GameObject.Find("Bucket_07").GetComponent<BoxCollider>();
            bucket03Collider = GameObject.Find("Bucket_03").GetComponent<BoxCollider>();

            // 子の名前 "Bucket_10" 、かつ "Bucket_07" との接触がある場合。Physics.CheckBox()は箱状の領域の衝突をチェック、
            if (gameObject.name == "Bucket_10" && Physics.CheckBox(transform.position, bucket07Collider.size / 2))
            {
                if (num7 < 7)
                {
                    int y = 7 - num7;
                    for (int i = (num10 - 1); y >= 0; y--)
                    {
                        if (i >= 0)
                        {
                            Bucket_Ten[i].SetActive(false);
                            i -= 1;
                            if ((num7 + y) <= 7 && y >= 0)
                            {
                                Bucket_Seven[num7 + y].SetActive(true);
                                y -= 1;
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
            else if (gameObject.name == "Bucket_10" && Physics.CheckBox(transform.position, bucket03Collider.size / 2))
            {
                if (num3 < 3)
                {
                    int y = 3 - num3;
                    for (int i = (num10 - 1); y >= 0; y--)
                    {
                        if (i >= 0)
                        {
                            Bucket_Ten[i].SetActive(false);
                            i -= 1;
                            if ((num3 + y) <= 3 && y >= 0)
                            {
                                Bucket_Three[num3 + y].SetActive(true);
                                y -= 1;
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
            else if (gameObject.name == "Bucket_07" && Physics.CheckBox(transform.position, bucket10Collider.size / 2))
            {
                if (num10 < 10)
                {
                    int y = 10 - num10;
                    for (int i = (num7 - 1); y >= 0; y--)
                    {
                        if (i >= 0)
                        {
                            Bucket_Seven[i].SetActive(false);
                            i -= 1;
                            if ((num10 + y) <= 10 && y >= 0)
                            {
                                Bucket_Ten[num10 + y].SetActive(true);
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
            else if (gameObject.name == "Bucket_07" && Physics.CheckBox(transform.position, bucket03Collider.size / 2))
            {
                if (num3 < 3)
                {
                    int y = 3 - num3;
                    for (int i = (num7 - 1); y >= 0; y--)
                    {
                        if (i >= 0)
                        {
                            Bucket_Seven[i].SetActive(false);
                            i -= 1;
                            if ((num3 + y) <= 3 && y >= 0)
                            {
                                Bucket_Three[num3 + y].SetActive(true);
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
            else if (gameObject.name == "Bucket_03" && Physics.CheckBox(transform.position, bucket10Collider.size / 2))
            {
                if (num10 < 10)
                {
                    int y = 10 - num10;
                    for (int i = (num3 - 1); y >= 0; y--)
                    {
                        if (i >= 0)
                        {
                            Bucket_Three[i].SetActive(false);
                            i -= 1;
                            if ((num10 + y) <= 10 && y >= 0)
                            {
                                Bucket_Ten[num10 + y].SetActive(true);
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
            else if (gameObject.name == "Bucket_03" && Physics.CheckBox(transform.position, bucket07Collider.size / 2))
            {
                if (num7 < 7)
                {
                    int y = 7 - num7;
                    for (int i = (num3 - 1); y >= 0; y--)
                    {
                        if (i >= 0)
                        {
                            Bucket_Three[i].SetActive(false);
                            i -= 1;
                            if ((num7 + y) <= 7 && y >= 0)
                            {
                                Bucket_Seven[num7 + y].SetActive(true);
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
}
