using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    //あいたドアに入った処理
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //リスポーン地点へ
        RetroPL.nowMode = RetroPL.PlayerMode.clear;
    }
}
