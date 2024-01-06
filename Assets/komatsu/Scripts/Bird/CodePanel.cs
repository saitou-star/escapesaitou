using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CodePanel : MonoBehaviour
{
    [SerializeField] 
    private Text numberText; //表示する数字
    public int number = 0; //内部の数字

    //クリックされたら数字を増やす
    public void OnClick() 
    {
        number++;
        if(number >= 10) 
        {
            number = 0;       
        }
        numberText.text = number.ToString();    
    }
}