using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0649

public class Traps : MonoBehaviour
{
    //トラップ(岩とモンスター)の出現処理

    [SerializeField] GameObject rockPrefab;//岩オブジェクト
    [SerializeField] GameObject birdPrefab;//鳥オブジェクト

    float[] rockSpans = {1.0f,0.6f,0.4f};//岩が落ちる感覚(レベル別)
    float[] birdSpans = {20f,19f,18f};//鳥が出現する感覚(レベル別)
    float goRockNowTime = 0;//岩タイマー
    float goBirdNowTime = 0;//鳥タイマー
    
    int level;//現在のレベル

    void Start()
    {
        //RetroPL.csからレベルを取得
        level = RetroPL.LevelCount();
    }
    
    void Update()
    {
        //岩の処理ーーーーー
        this.goRockNowTime += Time.deltaTime;
        if (goRockNowTime > rockSpans[level-1])
        {
            //タイマーリセット
            goRockNowTime = 0;
            //岩オブジェクト複製
            GameObject go = Instantiate(rockPrefab) as GameObject;
            //位置をランダムで設定
            float pos = Random.Range(-7.7f, 7.7f);
            go.transform.position = new Vector3(pos, 5, 0);
        }

        //鳥の処理ーーーーー
        this.goBirdNowTime += Time.deltaTime;
        if (goBirdNowTime > birdSpans[level - 1])
        {
            Debug.Log("鳥が出現！");
            //タイマーリセット
            goBirdNowTime = 0;
            //鳥オブジェクト複製
            GameObject go = Instantiate(birdPrefab) as GameObject;
            //位置を設定(Bird.csで修正されるのでここの値はあまり意味がない)
            go.transform.position = new Vector3(10, 2, 0);
        }

    }
    //時間があれば落ちる速さをいじってもよさそう....
}
