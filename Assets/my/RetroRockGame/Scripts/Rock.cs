using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    //岩のアニメーションとサウンド管理
    Animator anim;
    AudioSource audio;
    public AudioClip sound;
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //サウンド再生
        audio.PlayOneShot(sound);
        //アニメーション起動
        anim.SetBool("Destroy", true);
        //破壊
        Destroy(this.gameObject, 0.5f);
        
    }
}
