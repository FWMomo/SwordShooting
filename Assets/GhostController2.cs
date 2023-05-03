using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController2 : MonoBehaviour
{
    //消去位置
    private float deadLine = -20;
    //移動速度
    private float f = 1 / 1.3f;
    private float speedRate = -10;
    private float speedX = 0;
    private float speedY = 0;
    //敵の体力
    private int hp = 2;
    //必殺技用;
    GameObject energy;
    //必殺技チャージ率
    private int point = 1;
    //剣の攻撃力を格納
    public GameObject knight;
    private int knightSwordPower;
    private int knightKnifePower;
    //
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.Find("Energy");
        //剣の攻撃力を取得
        knight = GameObject.Find("Knight");

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        speedX = 20 + speedRate * time;
        speedY = 2 * Mathf.Sin(2 * Mathf.PI * f * time);
        //移動速度
        this.transform.position = new Vector3(speedX, speedY, 0);
        //画面端で消去
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
        //HPがゼロになった時に対象を消す
        if (hp <= 0)
        {
            energy.GetComponent<EnergyController>().EnergyCharger(point);
            Destroy(this.gameObject);
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
