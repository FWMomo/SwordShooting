using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : MonoBehaviour
{
    //消去位置
    private float deadLine = -20;
    //移動速度
    private float speedX = -6;
    private float speedY = 1;
    //敵の体力
    private int hp = 1;
    //弾プレハブ
    public GameObject enemyAtackPrefab;
    //攻撃間隔
    private float atackTime = 4f;
    //時間
    private float time = 0;
    //初撃までの時間
    private float firstAtackTime = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        firstAtackTime += atackTime;
    }

    // Update is called once per frame
    void Update()
    {
        //攻撃
        time += Time.deltaTime;
        if (time >= atackTime - firstAtackTime)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab);
            EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            time = 0;
            firstAtackTime = 0;
        }

        //移動
        this.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        //画面端で消去
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //味方の弾との接触判定
    void OnTriggerEnter2D(Collider2D other)
    {
        //KnightSwordに接触した時の判定
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //KnightKnifeに接触した時の判定
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //HPがゼロになった時に対象を消す
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
