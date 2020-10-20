using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    //Cloud.csに呼び出される関数
    public void PlayThunder()
    {
        //雷アニメーション起動
        anim.SetTrigger("shotTrigger");
    }
}
