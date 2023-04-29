using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : MonoBehaviour
{
    //Á‹ˆÊ’u
    private float deadLine = -20;
    //ˆÚ“®‘¬“x
    private float speedX = -6;
    private float speedY = 10;
    //“G‚Ì‘Ì—Í
    private int hp = 1;
    //ŠÔ
    private float time = 0; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //ˆÚ“®‘¬“x
        this.transform.position = new Vector2(0,Mathf.Sin(Time.deltaTime * speedY));
        this.transform.Translate(speedX, 0,0);
        //‰æ–Ê’[‚ÅÁ‹
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //–¡•û‚Ì’e‚Æ‚ÌÚG”»’è
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KnightSwordTag")
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
