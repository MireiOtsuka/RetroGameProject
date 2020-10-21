using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 0649
public class UImain : MonoBehaviour
{
    int timer;//カウントタイマー
    //残り時間(テキスト)
    [SerializeField] Text timerText;
    //定員
    [SerializeField] Text capa;
    //現在のクリア人数
    [SerializeField] Text clearPerson;
    //スコア
    [SerializeField] Text score;

    //ライフ表示
    [SerializeField] GameObject life4;
    [SerializeField] GameObject life3;
    [SerializeField] GameObject life2;
    [SerializeField] GameObject life1;
    [SerializeField] GameObject life0;

    void Start()
    {
        //定員表示
        capa.text = RetroPL.clearCapa[(RetroPL.level) - 1].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //タイマー設定ーーーーーーーーー
        //時間を引いていく
        RetroPL.time -= Time.deltaTime;
        //小数点を切るためにtimeをint型で表す
        timer = (int)RetroPL.time;
        //テキストに表示
        timerText.text = timer.ToString();
        if (RetroPL.time <= 0)
        {
            timer = 0;
            RetroPL.nowMode = RetroPL.PlayerMode.gameover;
        }

        //現在のクリア人数表示
        clearPerson.text = RetroPL.clearCount.ToString();
        //スコアの表示
        score.text = RetroPL.score.ToString();

        if (RetroPL.HP == 4)
        {
            life4.SetActive(true);
        }
        else if (RetroPL.HP == 3)
        {
            life3.SetActive(true);
            life4.SetActive(false);
        }
        else if (RetroPL.HP == 2)
        {
            life2.SetActive(true);
            life3.SetActive(false);
        }
        else if (RetroPL.HP == 1)
        {
            life1.SetActive(true);
            life2.SetActive(false);
        }
        else if (RetroPL.HP == 0)
        {
            life0.SetActive(true);
            life1.SetActive(false);
        }
    }
}
