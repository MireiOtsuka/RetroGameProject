﻿using System.Collections;
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

    bool gameContinue;
    
    void Start()
    {
        if (RetroPL.nowMode == RetroPL.PlayerMode.gameclear)
        {
            clearObj.SetActive(true);
        }else if (RetroPL.nowMode == RetroPL.PlayerMode.gameover)
        {
            overObj.SetActive(true);
        }
        Debug.Log("リザルト状態："+RetroPL.nowMode);
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
