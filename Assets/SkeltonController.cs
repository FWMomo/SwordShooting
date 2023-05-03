using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonController : MonoBehaviour
{
    //Á‹ˆÊ’u
    private float deadLine = -20;

    //ˆÚ“®‘¬“x
    private float speed = -5;
    //“G‚Ì‘Ì—Í
    private int hp = 30;
    //UŒ‚Ši”[
    public GameObject enemyAtackPrefab2;
    //UŒ‚ŠÔŠu
    private float atackTime = 2.0f;
    //ŠÔ
    private float time = 0;
    //ƒJƒEƒ“ƒg
    int count = 0;

    //•KE‹Z—p
    GameObject energy;
    //•KE‹Zƒ`ƒƒ[ƒW—¦
    private int point = 1;
    //Œ•‚ÌUŒ‚—Í‚ğŠi”[
    public GameObject knight;
    private int knightSwordPower;
    private int knightKnifePower;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.Find("Energy");
        //Œ•‚ÌUŒ‚—Í‚ğæ“¾
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
    }

    // Update is called once per frame
    void Update()
    {
        //ˆÚ“®‘¬“x
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        if (this.transform.position.x <= 14)
        {
            this.speed = 0;
            //UŒ‚O‰ñŒJ‚è•Ô‚·
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
        //‰æ–Ê’[‚ÅÁ‹
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //–¡•û‚Ì’e‚Æ‚ÌÚG”»’è
    void OnTriggerEnter2D(Collider2D other)
    {
        //KnightSword‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightSwordTag")
        {
            //”í’e‚Ì“xUŒ‚—Í‚ğ‘ª‚é
            this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;

            this.hp -= this.knightSwordPower;
            Destroy(other.gameObject);
        }
        //KnightKnife‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            //”í’e‚Ì“xUŒ‚—Í‚ğ‘ª‚é
            this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
            this.hp -= this.knightKnifePower;
            Destroy(other.gameObject);
        }
        //HP‚ªƒ[ƒ‚É‚È‚Á‚½‚É‘ÎÛ‚ğÁ‚·
        if (hp <= 0)
        {
            energy.GetComponent<EnergyController>().EnergyCharger(point);
            Destroy(this.gameObject);
        }
    }

}