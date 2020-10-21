using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0649

public class Traps : MonoBehaviour
{
    //トラップ(岩とモンスター)の出現処理

    [SerializeField] GameObject rockPrefab;//岩オブジェクト

    float[] rockSpans = {1.0f,0.6f,0.4f};//岩が落ちる感覚(レベル別)
    float rockNowTime = 0;//岩タイマー
    //現在のレベル
    int level;
    void Start()
    {
        //RetroPL.csからレベルを取得
        level = RetroPL.LevelCount();
    }

    // Update is called once per frame
    void Update()
    {
        //岩の処理ーーーーー
        this.rockNowTime += Time.deltaTime;
        if (rockNowTime > rockSpans[level-1])
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
    //時間があれば落ちる速さをいじってもよさそう....
}
