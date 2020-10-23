using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    //雲の処理

    Animator anim;
    Thunder thunder;//Thunder.cs取得
    private GameObject thunderObj;//雷(子オブジェクト)

    //ランダムで雷タイマーの時間の範囲を格納するレベル別配列
    float[] thMinSpans = { 5f, 3.5f, 2f };//最小値
    float[] thMaxSpans = { 10f, 8f, 5f };//最大値

    int level;//現在のレベル
    float cloudSpans;//雷が落ちる感覚
    float cloudNowTimes;//雷タイマー

    //Thunder.csと共通で使う変数ーーーー
    bool cloudGo = false;//雷雲が変化するとき使うフラグ
    bool cloudAnimFlag = false;//雲が黒くなり続けるフラグ
    bool thunderGo = false;//雷のGoサイン

    void Start()
    {
        anim = GetComponent<Animator>();
        //現在のレベルを取得
        level = RetroPL.LevelCount();
        //ランダムで雷タイマーの時間を決める
        cloudSpans = Random.Range(thMinSpans[level-1], thMaxSpans[level-1]);
        //タイマー初期化
        cloudNowTimes = 0f;
        //アニメーションフラグをfalseにする
        cloudGo = false;
        //clouObjの子オブジェクト取得
        thunderObj = transform.Find("ShotThunder").gameObject;
        //子オブジェクトのthunder.cs取得
        thunder = thunderObj.GetComponent<Thunder>();
    }

    // Update is called once per frame
    void Update()
    {
        //雷の処理ーーーー
        //タイマーで時間を計測
        cloudNowTimes += Time.deltaTime;
        //時間になったら雷処理実行
        if (cloudNowTimes > cloudSpans)
        {
            //起動フラグをtrueにする
            cloudGo = true;
            //アニメーションフラグをtrueにする
            cloudAnimFlag = true;
            //タイマーリセット
            cloudNowTimes = 0;
            //ランダムで雷タイマーの時間を決める
            cloudSpans = Random.Range(thMinSpans[level - 1], thMaxSpans[level - 1]);
            //Shot関数呼び出し
            StartCoroutine("Shot");
        }
        //雷雲アニメーション
        if (cloudAnimFlag)
        {
            //黒雲アニメーション起動
            anim.SetBool("shotCloud", true);
        }
        else
        {
            //白雲アニメーション起動
            anim.SetBool("shotCloud", false);
        }
    }

    //ルーチンを止めることができる関数
    IEnumerator Shot()
    {
        //ここのブロック全体のルーチンを止めてしまうため(アニメーションも止める)
        //ここに動きのある処理を入れないこと
        cloudGo = false;
        //黒くもアニメーションの1秒後に下の処理をする
        yield return new WaitForSeconds(1f);
        //Thunder.csへ処理が続く
        thunder.PlayThunder();
        //1.2秒後に雷終わり
        yield return new WaitForSeconds(1.2f);
        cloudAnimFlag = false;
    }


    //参考サイト
    //unity 親csから子オブジェクトのcsをいじる方法
    //https://qiita.com/hiroyuki7/items/95c66aee26115cf24a19

    //10.2時点の問題
    //実装したいことーーーー
    //ランダム関数を入れて4つの雲からランダムに雷が落ちるようにしたい
    //問題点ーーーー
    //同じタイミングで雷が落ちてしまう
    //プレハブ化しなくてもこの現象が起きる
    //10.4　処置②のおかげでプレハブもランダムに動くようになった
    //処置①ーーーー
    //応急処置としてtransform.position.zの値を
    //ランダム変数にかける
    //      ↓
    //共通のアニメーションboolを持っているため一番短い時間のものに引っ張られる
    //処置②ーーーー
    //全てprivate変数にする
    //public static bool cloudGo = false;//雲の色を変化させる
    //public static bool thunderGo = false;//雷のGoサイン
    //上のものに設定していたためフラグが同じになってしまった

}
