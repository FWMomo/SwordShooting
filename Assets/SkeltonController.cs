using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonController : MonoBehaviour
{
    //消去位置
    private float deadLine = -20;

    //移動速度
    private float speed = -5;
    //敵の体力
    private int hp = 30;
    //攻撃格納
    public GameObject enemyAtackPrefab2;
    //攻撃間隔
    private float atackTime = 2.0f;
    //時間
    private float time = 0;
    //カウント
    int count = 0;

    //必殺技用
    GameObject energy;
    //必殺技チャージ率
    private int point = 1;
    //剣の攻撃力を格納
    public GameObject knight;
    private int knightSwordPower;
    private int knightKnifePower;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.Find("Energy");
        //剣の攻撃力を取得
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
    }

    // Update is called once per frame
    void Update()
    {
        //移動速度
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        if (this.transform.position.x <= 14)
        {
            this.speed = 0;
            //攻撃三回繰り返す
            time += Time.deltaTime;
            if (time >= atackTime && count < 10)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab2);
                EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);

                GameObject EnemyAtackPrefab1 = Instantiate(enemyAtackPrefab2);
                EnemyAtackPrefab1.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                EnemyAtackPrefab1.GetComponent<EnemyShotController2>().SetY(2);

                GameObject EnemyAtackPrefab2 = Instantiate(enemyAtackPrefab2);
                EnemyAtackPrefab2.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                EnemyAtackPrefab2.GetComponent<EnemyShotController2>().SetY(4);

                count++;
                time = 0;
            }
        }
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
            //被弾の度攻撃力を測る
            this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;

            this.hp -= this.knightSwordPower;
            Destroy(other.gameObject);
        }
        //KnightKnifeに接触した時の判定
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            //被弾の度攻撃力を測る
            this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
            this.hp -= this.knightKnifePower;
            Destroy(other.gameObject);
        }
        //HPがゼロになった時に対象を消す
        if (hp <= 0)
        {
            energy.GetComponent<EnergyController>().EnergyCharger(point);
            Destroy(this.gameObject);
        }
    }

}