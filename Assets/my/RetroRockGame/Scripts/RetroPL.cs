using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetroPL : MonoBehaviour
{
    //プレイヤーの処理

    Rigidbody2D rb2d;
    Animator anim;

    public static int level = 1;//レベル
    public static int[] clearCapa = { 1, 2, 20 };//レベル別クリア人数
    public static int[] times = { 5, 10, 20 };//レベル別追加時間

    float speed = 5.0f;//移動のスピード
    bool isGround = false;//接地判定
    public static float time = 100;//制限時間
    public static int HP = 4;//HP
    public static int clearCount = 0;//クリアした人数
    public static int score = 0;//スコア

    /// <summary>
    /// プレイヤーの状態管理
    /// </summary>
    public enum PlayerMode
    {
        action,    //アクション中     action=0;
        damage,    //ダメージ中       damage=1;
        clear,     //ドアに入った時   clear=2
        gameover,  //ゲームオーバー   gameover=3;
        gameclear  //ゲームクリア     gameclear=4; と定数を持っている

    }

    /// <summary>
    /// 現在のプレイヤーの状態
    /// </summary>
    /// シーン遷移してもこの値が保存されるようにstaticをつける
    public static PlayerMode nowMode = PlayerMode.action;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        //ゲームスタート時アクションモードでスタート
        nowMode = PlayerMode.action;
        //レベル1の時はすべて初期化
        if (level == 1) {
            //HP初期化
            HP = 4;
            //クリア人数初期化
            clearCount = 0;
            //スコア
            score = 0;
            //制限時間
            time = 100 + times[level - 1];
        }
        else
        {   //レベル2以降はclearCountのみ初期化
            //HPは引き継ぐ
            //クリア人数初期化
            clearCount = 0;
            //制限時間を付け足す
            time += times[level - 1];
        }
    }
    
    void Update()
    {
        //ゲームオーバー
        if (HP == 0||time<=0)
        {   //ダメージを受けて死ぬ場合
            if (HP == 0)
            {
                //レベル1に戻す
                level = 1;
                //すぐに移行はしてほしくない
                anim.SetBool("GameOver", true);
            }
            //シーン移行の関数呼び出し
            StartCoroutine("GoResult");
        }
        //扉に入ったら関数よびだす
        if (nowMode == PlayerMode.clear)
        {
            ModeClear();
        }
        //アクション中以外は操作＆アニメーション切り替え不可
        if (nowMode != PlayerMode.action) return;

        //移動処理
        //GetAxisRawは1,0,-1がピタッと移り変わる
        float h = Input.GetAxisRaw("Horizontal");

        //プレイヤーの移動速度を設定する
        rb2d.velocity =
            new Vector2(h * speed, rb2d.velocity.y);

        //実験
        //方向転換処理--------------------------------

        //方向転換するタイミング
        //右移動・・・左を向いているとき moveX>0 && scale.x<0
        //左移動・・・右を向いているとき moveX<0 && scale.x>0

        //現時点でのscale値を取得
        Vector3 scale = transform.localScale;
        //任意のタイミングで方向転換処理
        if ((h > 0 && scale.x < 0)
            || (h < 0 && scale.x > 0))
        {
            //移動に対して逆を向いているとき
            scale.x *= -1;
            transform.localScale = scale;
        }
        
        //アニメーション
        //moveXが０になっていなかったらtrue
        anim.SetBool("isMove", h != 0);
        anim.SetFloat("Speed", h);
        
        //ジャンプ処理
        if (Input.GetButtonDown("Jump")&&isGround)
        {
            //ジャンプ
            rb2d.AddForce(Vector2.up * 300f);
        }
    }

    /// <summary>
    /// 敵・アイテムの当たり判定
    /// isTriggerにチェックは入れない
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        //岩,鳥との判定
        if (collision.gameObject.tag == "Rock"&&nowMode==PlayerMode.action)
        {
            //HPを1引く
            HP--;
            //ぶつかったアニメーション再生
            anim.SetTrigger("rockDamage");
            //PLAnimation()に飛ぶ
            StartCoroutine("PLAnimation");
            //ダメージ状態に移行
            nowMode = PlayerMode.damage;
        }
    }
    
    /// <summary>
    /// 接地判定(地面についているとき)
    /// isTriggerにチェックが入っているboxColliderを使用
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //接地判定
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

        //雷との判定
        //ダメージをくらうと進路方向に滑るように移動してしまう
        if (collision.gameObject.tag == "Thunder" && nowMode == PlayerMode.action)
        {
            //HPを1引く
            HP--;
            //うたれたアニメーション再生
            anim.SetTrigger("thunderDamage");
            //PLAnimation()に飛ぶ
            StartCoroutine("PLAnimation");
            //ダメージ状態に移行
            nowMode = PlayerMode.damage;
        }
    }
    /// <summary>
    /// 接地判定(地面についていないとき)
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        //接地判定
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    IEnumerator PLAnimation()
    {
        //ここのブロック全体のルーチンを止めてしまうため(アニメーションも止める)
        //ここに動きのある処理を入れないこと
        yield return new WaitForSeconds(1.5f);

        //HPが0の場合はactionモードに切り替えない
        if (HP == 0) nowMode = PlayerMode.gameover;
        //0以外はまた動けるようにactionモードに切り替える
        else nowMode = PlayerMode.action;
    }

    /// <summary>
    /// 扉に入った時
    /// </summary>
    void ModeClear()
    {
        //クリアカウントプラス
        clearCount++;
        //スコア加算1人につき100点*level
        score += 100 * level;
        //モード変更
        nowMode = PlayerMode.action;
        //規定人数満たしたらクリア
        if (clearCapa[level - 1] == clearCount)
        {
            //1面クリアごとにスコア加算
            //基礎ポイント＋時間ポイント
            score += 1000 * level+(int)time*10;
            //モード変更
            nowMode = PlayerMode.gameclear;
            //レベルを上げる
            level++;
            //シーン移行の関数呼び出し
            StartCoroutine("GoResult");
        }
        //transformを取得
        Transform myTransform = this.transform;
        //リスポーン地点に移動する
        Vector2 pos = new Vector2(-8, -3.3f);
        //座標を設定
        myTransform.position = pos;
    }

    /// <summary>
    /// ゲームオーバーorクリア時に呼び出される
    /// </summary>
    /// <returns></returns>
    IEnumerator GoResult()
    {
        //待つ
        yield return new WaitForSeconds(1.5f);
        //リザルト画面に移動
        SceneManager.LoadScene("Result_Retro2D");
    }

    /// <summary>
    /// プロパティーで値(ゲームスコア)を渡す
    /// </summary>
    /// <returns>Scoreの値</returns>
    public static int ScoreCount()
    {
        return score;
    }
    /// <summary>
    /// レベルの値を返す
    /// </summary>
    /// <returns></returns>
    public static int LevelCount() {
        return level;
    }
}
