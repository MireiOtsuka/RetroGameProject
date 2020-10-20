using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    //矢印をよけるぬこゲーのUI管理スクリプト

    GameObject hpGauge;

    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    public void DecreaseHp()
    {
        //Decrease(デクリース)：減少
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
