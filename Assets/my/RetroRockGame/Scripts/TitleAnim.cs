using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    //タイトルアニメーション

    Animator anim;
    float nowTime = 0;//タイマー

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime >= 60)
        {
            //タイマーリセット
            nowTime = 0;
            //アニメーション発動
            anim.SetTrigger("Start");
        }
    }
}
