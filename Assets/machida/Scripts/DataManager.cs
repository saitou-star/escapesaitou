// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DataManager : MonoBehaviour
// {
//     [SerializeField] PlayerPositionGetter playerPositionGetter = default;
//     // Start is called before the first frame update
//     public static PlayerPositionGetter instance;

//     public void Awake()
//     {
//         instance = this;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // プレイヤーの位置をログに出力
//         if (playerPositionGetter.playerTransform != null)
//         {
//             Debug.Log("Player Position: " + playerPositionGetter.playerTransform.position);
//         }
//     }
// }
