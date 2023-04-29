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

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    //–¡•û‚Ì’e‚Æ‚ÌÚG”»’è
    void OnTriggerEnter2D(Collider2D other)
    {
        //KnightSword‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 2;
            Destroy(other.gameObject);
        }
        //KnightKnife‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //HP‚ªƒ[ƒ‚É‚È‚Á‚½‚É‘ÎÛ‚ğÁ‚·
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
