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
    private float hp = 60;
    //攻撃格納
    public GameObject enemyAtackPrefab2;

    //必殺技用
    GameObject energy;
    //必殺技チャージ率
    private int point = 15;
    //剣の攻撃力を格納
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
    }

    // Update is called once per frame
    void Update()
    {
        //移動速度
        transform.Translate(this.speed * Time.deltaTime, 0, 0);


        if (this.transform.position.x <= 14 && this.speed != 0)
        {
            StartCoroutine(Atack());
        }

        //画面端で破壊
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }
    
    IEnumerator Atack()
    {
        this.speed = 0;
        for(int i = 0; i < 6; i++)
        {
            for (int j = -1; j < 6; j++)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab2);
                EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                EnemyAtackPrefab.GetComponent<EnemyShotController2>().SetSpeed(-10, -4 + 2 * j);
            }
            yield return new WaitForSeconds(3);
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