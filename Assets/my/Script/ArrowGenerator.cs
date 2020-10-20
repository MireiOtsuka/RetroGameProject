using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //矢を生成するジェネレータースクリプト

    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }

        /*as GameObject とは
          キャスト(強制型変換)をしている
          
          Instantiateメソッドは最も基本的なObject型を返す
          しかし、GameObject型で受け取りたいので変換をした*/
    }
}
