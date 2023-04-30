using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    //Á‹ˆÊ’u
    private float deadLine = -20;
    //ˆÚ“®‘¬“x
    private float speed = -6;
    //“G‚Ì‘Ì—Í
    private int hp = 2;
    //•KE‹Z—p;
    GameObject energy;
    //•KE‹Zƒ`ƒƒ[ƒW—¦
    private int point = 1;
    //KnightController‚©‚çŒ»İ‚ÌUŒ‚—Í‚ğæ“¾‚·‚é‚½‚ß
    GameObject knight;
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

        //‰æ–Ê’[‚ÅÁ‹
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
        //HP‚ªƒ[ƒ‚É‚È‚Á‚½‚É‘ÎÛ‚ğÁ‚·
        if (hp <= 0)
        {
            energy.GetComponent<EnergyController>().EnergyCharger(point);
            Destroy(this.gameObject);
        }
    }

    //–¡•û‚Ì’e‚Æ‚ÌÚG”»’è
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //KnightSword‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= this.knightSwordPower;
            Destroy(other.gameObject);
        }
        //KnightKnife‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightKnifeTag")
        {
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
