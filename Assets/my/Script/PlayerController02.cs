using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController02 : MonoBehaviour
{
    //猫が雲を登っていくゲームのプレイヤースクリプト
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);

        }

        //反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.animator.SetFloat("Speed", speedx);
        //歩く速度に応じてアニメーション速度を変える
        //this.animator.speed=speedx/2.0f;
    }
}
