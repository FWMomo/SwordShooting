using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController2 : MonoBehaviour
{
    //Á‹ˆÊ’u
    private float deadLine = -20;
    //ˆÚ“®‘¬“x
    private float f = 1 / 1.3f;
    private float speedRate = -10;
    private float speedX = 0;
    private float speedY = 0;
    //“G‚Ì‘Ì—Í
    private float hp = 3;
    //•KE‹Z—p;
    GameObject energy;
    //•KE‹Zƒ`ƒƒ[ƒW—¦
    public int point = 2;
    //Œ•‚ÌUŒ‚—Í‚ğŠi”[
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;
    //‰ŠúˆÊ’uŠi”[—p
    public float positionX = 0;
    public float positionY = 0;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.Find("Energy");
        //Œ•‚ÌUŒ‚—Í‚ğæ“¾
        knight = GameObject.Find("Knight");

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        speedX = speedRate * time;
        speedY = 2 * Mathf.Sin(2 * Mathf.PI * f * time);
        //ˆÚ“®‘¬“x
        this.transform.position = new Vector3(positionX + speedX, positionY + speedY, 0);
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

    public void Position(float positionX, float positionY)
    {
        this.positionX = positionX;
        this.positionY = positionY;
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
