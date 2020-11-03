using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    AudioSource audio;
    //鳥の移動スクリプト
    [SerializeField] GameObject firePrefab;//隕石オブジェクト
    public AudioClip sound;//炎の音
    //ランダムで雷タイマーの時間の範囲を格納するレベル別配列
    float[] fiMinSpans = { 5f, 4f, 3f };//最小値
    float[] fiMaxSpans = { 7f, 6f, 5f };//最大値
    int level;//現在のレベル
    float fireSpans;//隕石が落ちる感覚
    float fireNowTime = 0;//隕石タイマー
    float birdNowTime = 0;//鳥飛ぶタイマー
    float speed;//モンスターの速度
    float hight;//モンスターの飛ぶ高さ
    //軌道関連
    //オブジェクトのRigidbody2DをKinematicにして自分で管理する
    private new Rigidbody2D rigidbody;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
        //重力なしに設定
        rigidbody.gravityScale = 0.0f;
        //物理演算の影響あり
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        //現在のレベルを取得
        level = RetroPL.LevelCount();
        //ランダムで隕石タイマーの時間を決める
        fireSpans = Random.Range
            (fiMinSpans[level - 1], fiMaxSpans[level - 1]);
        //ランダムでモンスターのスピードを決める
        speed = Random.Range(0.5f, 0.2f);
        //飛ぶ高さ
        hight = Random.Range(1f, 1.7f);
        //タイマー初期化
        fireNowTime = 0f;
    }
    
    void Update()
    {
        //鳥の処理ーーーーー
        //時間で上下しながら左に動く
        birdNowTime += Time.deltaTime;//左に動かす
        var t = birdNowTime - 9;//左に動かす
        var x = t;//左に動かす
        var y = Mathf.Sin(speed * Mathf.PI * t)*hight;//上下に動かす
        rigidbody.MovePosition(new Vector2(-x, y - 2f));
        //この処理のせいで上下する動きがおんなじ
        //そのため改善が必要
        //Sin(2fのところを乱数にすれば改善か...?
        //2020.10.27改善
        //sinに数字を掛けることで縦幅を変えることに成功

        //画面外処理(鳥)
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }


        //隕石の処理ーーーーー
        this.fireNowTime += Time.deltaTime;
        if (fireNowTime > fireSpans)
        {
            //タイマーリセット
            fireNowTime = 0;
            //隕石オブジェクト複製
            GameObject go = Instantiate(firePrefab) as GameObject;
            go.transform.position = transform.position;
            //ランダムで隕石タイマーの時間を決める
            fireSpans = Random.Range
                (fiMinSpans[level - 1], fiMaxSpans[level - 1]);
            //サウンド再生
            audio.PlayOneShot(sound);
        }
    }

    //参考サイト
    //Sinを用いて軌道を作る
    //https://teratail.com/questions/149071
}
