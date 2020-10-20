using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    //右扉の管理
    public GameObject openDoor;
    public GameObject closeDoor;
    bool openFlag = false;
    float randomTime;
    float nowTime = 0f;
    void Start()
    {
        //初期化
        openFlag = false;
        nowTime = 0f;
        openDoor.SetActive(false);
        closeDoor.SetActive(true);
        //あく時間をランダムで設定
        randomTime = Random.Range(1f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime > randomTime && openFlag)
        {
            //タイマーリセット
            nowTime = 0;
            //ドアを閉める
            openDoor.SetActive(false);
            closeDoor.SetActive(true);
            //openFlagをfalseに
            openFlag = false;
            //次のrandomTimeの値を決める
            RandomTime();
        }
        else if(nowTime> randomTime && !openFlag)
        {
            //タイマーリセット
            nowTime = 0;
            //ドアを開ける
            openDoor.SetActive(true);
            closeDoor.SetActive(false);
            //openFlagをtrueに
            openFlag = true;
            //次のrandomTimeの値を決める
            RandomTime();
        }
    }

    void RandomTime()
    {
        //あく時間をランダムで設定
        randomTime = Random.Range(1f, 8f);
    }
    
}
