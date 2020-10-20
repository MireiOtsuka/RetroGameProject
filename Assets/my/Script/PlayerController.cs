using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*矢印をよけるぬこのスクリプト
      Unityの教科書P.184～*/


    void Start()
    {
       
    }

    void Update()
    {
        //左移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0);
        }

        //右移動
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            transform.Translate(3, 0, 0);
        }
        
    }
}
