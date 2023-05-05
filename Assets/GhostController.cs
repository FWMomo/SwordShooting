using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    //Á‹ˆÊ’u
    private float deadLine = 25;

    //ˆÚ“®‘¬“x
    private float speed = -5;
    //“G‚Ì‘Ì—Í
    private float hp = 3;
    //UŒ‚Ši”[
    public GameObject enemyAtackPrefab;
    //UŒ‚ŠÔŠu
    private float atackTime = 2.3f;
    //ŠÔ
    private float time = 0;
    //ƒJƒEƒ“ƒg
    int count = 0;

    //•KE‹Z—p
    GameObject energy;
    //•KE‹Zƒ`ƒƒ[ƒW—¦
    private int point = 2;
    //Œ•‚ÌUŒ‚—Í‚ğŠi”[
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;

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

        if(this.transform.position.x <= 14)
        {
            this.speed = 0;
            //UŒ‚O‰ñŒJ‚è•Ô‚·
            time += Time.deltaTime;
            if (time >= atackTime &&@count < 3)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab);
                EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                count++;
            }
            if(count == 3)
            {
                this.speed = 5;
            }
        }

        //‰æ–Ê’[‚ÅÁ‹
        if (this.transform.position.x > deadLine)
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
