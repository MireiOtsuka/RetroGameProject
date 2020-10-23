using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    //あいたドアに入った処理
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        //RetroPLで加点処理
        RetroPL.nowMode = RetroPL.PlayerMode.clear;
    }
}
