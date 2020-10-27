using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#pragma warning disable 0649

public class Result : MonoBehaviour
{
    // ゲームのリザルト画面管理
    [SerializeField] GameObject clearObj;
    [SerializeField] GameObject overObj;
    [SerializeField] Text socoreText;
    //レベル
    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;

    //コンティニューフラグ
    bool gameContinue;
    
    void Start()
    {
        Debug.Log(RetroPL.nowMode);
        if (RetroPL.nowMode == RetroPL.PlayerMode.gameclear)
        {
            clearObj.SetActive(true);
        }else if (RetroPL.nowMode == RetroPL.PlayerMode.gameover)
        {
            overObj.SetActive(true);
        }
        //RetroPLからscoreの値を読み込む
        int resultSrore = RetroPL.ScoreCount();
        //scoreTextにリザルトスコアを表示
        socoreText.text = resultSrore.ToString();
        //RetroPLからlevelの値を読み込む
        int level = RetroPL.LevelCount();
        //一回初期化
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        //レベル別表示
        if (level == 2) level1.SetActive(true);
        else if (level == 3) level2.SetActive(true);
        else level3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// リトライボタン
    /// </summary>
    public void RetryButton()
    {
        //Invoke("呼び出したい関数",何秒後か)でX秒後に関数が呼び出される
        Invoke("SceneChange", 0.5f);
        gameContinue = true;
    }
    /// <summary>
    /// エンドボタン
    /// </summary>
    public void EndButton()
    {
        //Invoke("呼び出したい関数",何秒後か)でX秒後に関数が呼び出される
        Invoke("SceneChange", 0.5f);
        gameContinue = false;
    }
    void SceneChange()
    {
        if (gameContinue)SceneManager.LoadScene("Game_Retro2D");
        else SceneManager.LoadScene("Start_Retro2D");
    }
}
