using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0649

public class Traps : MonoBehaviour
{
    //トラップ(岩とモンスター)の出現処理

    [SerializeField] GameObject rockPrefab;//岩オブジェクト

    float rockSpan = 1.0f;//岩が落ちる感覚
    float rockNowTime = 0;//岩タイマー
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //岩の処理ーーーーー
        this.rockNowTime += Time.deltaTime;
        if (rockNowTime > rockSpan)
        {
            //タイマーリセット
            rockNowTime = 0;
            //岩オブジェクト複製
            GameObject go = Instantiate(rockPrefab) as GameObject;
            //位置をランダムで設定
            float pos = Random.Range(-7.7f, 7.7f);
            go.transform.position = new Vector3(pos, 5, 0);
        }
       
    }
    
}
