using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //鳥の移動スクリプト
    [SerializeField] GameObject firePrefab;//隕石オブジェクト
    //ランダムで雷タイマーの時間の範囲を格納するレベル別配列
    float[] fiMinSpans = { 5f, 4f, 3f };//最小値
    float[] fiMaxSpans = { 7f, 6f, 5f };//最大値
    int level;//現在のレベル
    float fireSpans;//隕石が落ちる感覚
    float fireNowTime = 0;//隕石タイマー
    float speed = 0.01f;//モンスターの速度
    //軌道関連
    //オブジェクトのRigidbody2DをKinematicにして自分で管理する
    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //重力なしに設定
        rigidbody.gravityScale = 0.0f;
        //物理演算の影響あり
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        //現在のレベルを取得
        level = RetroPL.LevelCount();
        //ランダムで隕石タイマーの時間を決める
        fireSpans = Random.Range(fiMinSpans[level - 1], fiMaxSpans[level - 1]);
        //タイマー初期化
        fireNowTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //時間で動く
        var t = Time.time - 9;
        var x = t;
        var y = Mathf.Sin(2f * Mathf.PI * t);
        rigidbody.MovePosition(new Vector2(-x, y - 2f));

        //隕石の処理ーーーーー
        this.fireNowTime += Time.deltaTime;
        if (fireNowTime > fireSpans)
        {
            //タイマーリセット
            fireNowTime = 0;
            //岩オブジェクト複製
            GameObject go = Instantiate(firePrefab) as GameObject;
            go.transform.position = transform.position;
            //ランダムで隕石タイマーの時間を決める
            fireSpans = Random.Range(fiMinSpans[level - 1], fiMaxSpans[level - 1]);
            
        }
    }

    //参考サイト
    //Sinを用いて軌道を作る
    //https://teratail.com/questions/149071
}
