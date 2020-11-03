using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    //スコア関連
    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //ハイスコア用変数
    private string scorekey = "HIGH SCORE"; //ハイスコアの保存先キー
    int score = 0;//プレイスコアを入れる変数
    
    void Start()
    {
        //スコア関連
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScore = PlayerPrefs.GetInt(scorekey, 0);
        //スコア取得
        score = RetroPL.ScoreCount();
        //ハイスコアを表示
        highScoreText.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //ハイスコアより現在スコアが高い時
        if (score > highScore)
        {
            //ハイスコア更新
            highScore = score;
            //ハイスコアを保存
            PlayerPrefs.SetInt(scorekey, highScore);
        }
    }
}
