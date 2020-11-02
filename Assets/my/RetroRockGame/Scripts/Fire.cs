using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float speed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        //横に動く(画面の大きさで速度が変わってしまう)
        //FixedUpdateで解消
        transform.Translate(0, -speed, 0);

        //画面外処理(隕石)
        if (transform.position.x < -10|| 
            transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
