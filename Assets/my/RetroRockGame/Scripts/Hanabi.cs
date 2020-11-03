using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanabi : MonoBehaviour
{
    Animator anim;
    
    float speed;
    //Y軸について
    //float[] positionsY = { -1.96f, -0.5f, -1.7f, 2.5f };
    float[] positionsY = { -1.96f, -0.5f, -1.7f, 2.5f };
    public static int count = 0;
    bool GoFlag=false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //ランダムで速さ決定
        //speed = Random.Range(0.02f, 0.06f);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Go", true);
    }

    //プログラムで花火を実行しようとして失敗
    //void aaa()
    //{
    //    //カウントがｲﾝﾃﾞｯｸｽの範囲内にだったら実行
    //    if (count < positionsY.Length)
    //    {
    //        if (transform.position.y >= positionsY[count])
    //    {
    //        GoFlag = true;
    //    }
    //    else
    //    {
    //        transform.Translate(0, speed, 0);
    //    }
    //        if (GoFlag == true)
    //        {
    //            GoFlag = false;
    //            //生成された回数をカウント
    //            count++;
    //            //アニメーション発動
    //            anim.SetBool("Go", true);
    //        }
    //    }
    //}
    
}
