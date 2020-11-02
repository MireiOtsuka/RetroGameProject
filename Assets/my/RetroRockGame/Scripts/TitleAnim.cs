using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    //タイトルアニメーション

    Animator anim;
    float nowTime = 0;//タイマー
    bool animFlag = true;//アニメーションフラグ
    float animTime = 0;//アニメーションタイマー
    //岩アニメーションーーーー
    [SerializeField] GameObject rock;
    bool rockFlag = true;//岩投下フラグ
    //炎(右)アニメーションーーーー
    [SerializeField] GameObject rightFire;
    bool RFlag = true;//炎投下フラグ
    //炎(左)アニメーションーーーー
    [SerializeField] GameObject leftFire;
    bool LFlag = true;//炎投下フラグ

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
            //投下フラグon
            rockFlag = true;
            RFlag = true;
            LFlag = true;
            animFlag = true;
        }
        //投下開始処理--------------------
        if (animFlag)
        {
            //タイマー始動
            animTime += Time.deltaTime;
        }
        if (animTime >= 2.4f && RFlag)
        {
            RFlag = false;
            //炎オブジェクト複製
            GameObject go = Instantiate(rightFire) as GameObject;
            //投下
            go.transform.position = new Vector3(5.5f, -3, 0);
        }
        if (animTime >= 4.1f && LFlag)
        {
            LFlag = false;
            //炎オブジェクト複製
            GameObject go = Instantiate(leftFire) as GameObject;
            //投下
            go.transform.position = new Vector3(-8.25f, -3.2f, 0);
        }
        if (animTime >= 8f && rockFlag)
        {
            rockFlag = false;
            animTime = 0;
            //岩オブジェクト複製
            GameObject go = Instantiate(rock) as GameObject;
            //投下
            go.transform.position = new Vector3(4.5f, 5, 0);
        }
    }
}
