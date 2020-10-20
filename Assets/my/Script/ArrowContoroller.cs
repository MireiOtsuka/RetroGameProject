using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowContoroller : MonoBehaviour
{
    //矢印をよけるゲーム(矢印制御)

    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        //オブジェクト破棄
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //colliderを使わない当たり判定
        //矢の中心座標
        Vector2 p1 = transform.position;
        //プレイヤーの中心座標
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        //矢の半径
        float r1 = 0.5f;
        //プレイヤーの半径
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            //プレイヤーと衝突時にGameDirectorにわたす
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);
        }
    }
}
