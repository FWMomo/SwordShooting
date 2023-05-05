using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye2Controller : MonoBehaviour
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
        StartCoroutine(Atack());

        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
    }

    // Update is called once per frame
    void Update()
    {
        //ˆÚ“®
        this.transform.Translate(speedX * Time.deltaTime, 0, 0);

        //‰æ–Ê’[‚ÅÁ‹
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Atack()
    {
        yield return new WaitForSeconds(firstAtackTime);
        for (int i = 0; i < 5; i++)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab);
            EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            EnemyAtackPrefab.GetComponent<EnemyShotController2>().SetSpeed(-10, -2);
            yield return new WaitForSeconds(3);
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

