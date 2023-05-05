using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : MonoBehaviour
{
    //Á‹ˆÊ’u
    private float deadLine = -20;
    //ˆÚ“®‘¬“x
    private float speedX = -6;
    private float speedY = 1;
    //“G‚Ì‘Ì—Í
    private float hp = 2;
    //’eƒvƒŒƒnƒu
    public GameObject enemyAtackPrefab;
    //UŒ‚ŠÔŠu
    private float atackTime = 4f;
    //ŠÔ
    private float time = 0;
    //‰Œ‚‚Ü‚Å‚ÌŠÔ
    private float firstAtackTime = 0.4f;


    GameObject energy;
    //•KE‹Zƒ`ƒƒ[ƒW—¦
    private int point = 1;
    //Œ•‚ÌUŒ‚—Í‚ğŠi”[
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;

    // Start is called before the first frame update
    void Start()
    {
        //‰Œ‚‚Ü‚Å‚ÌŠÔ
        firstAtackTime += atackTime;

        energy = GameObject.Find("Energy");
        //Œ•‚ÌUŒ‚—Í‚ğæ“¾
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
    }

    // Update is called once per frame
    void Update()
    {
        //UŒ‚
        time += Time.deltaTime;
        if (time >= atackTime - firstAtackTime)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab);
            EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            time = 0;
            firstAtackTime = 0;
        }

        //ˆÚ“®
        this.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
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
