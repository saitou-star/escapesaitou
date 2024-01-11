using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice : MonoBehaviour
{
    public GameObject bucket;  // プレーヤーが物を持つバケツ
    public GameObject heldObject;  // プレーヤーが持っているオブジェクト
    private bool isHolding = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleHoldObject();
        }

        if (isHolding)
        {
            MoveHeldObjectToBucket();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TransferObjectToAnotherBucket();
        }
    }

    void ToggleHoldObject()
    {
        if (isHolding)
        {
            // 既に物を持っている場合は物を置く
            heldObject.transform.parent = null;  // 親子関係を解除
            isHolding = false;
        }
        else
        {
            // 物を持っていない場合は物を拾う
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                heldObject = hit.collider.gameObject;
                heldObject.transform.parent = transform;  // プレーヤーの子に設定
                isHolding = true;
            }
        }
    }

    void MoveHeldObjectToBucket()
    {
        if (heldObject != null)
        {
            heldObject.transform.position = bucket.transform.position;
        }
    }

    void TransferObjectToAnotherBucket()
    {
        if (isHolding && heldObject != null)
        {
            // もう一方のバケツにオブジェクトを移動
            GameObject anotherBucket = FindAnotherBucket();
            if (anotherBucket != null)
            {
                heldObject.transform.parent = anotherBucket.transform;
                heldObject.transform.localPosition = Vector3.zero;
                isHolding = false;
            }
        }
    }

    GameObject FindAnotherBucket()
    {
        // バケツを探す方法は状況によって変更する必要があります。
        // この例ではシンプルにタグ "AnotherBucket" を持つオブジェクトを探します。
        GameObject[] buckets = GameObject.FindGameObjectsWithTag("AnotherBucket");

        if (buckets.Length > 0)
        {
            return buckets[0];
        }

        return null;
    }
}