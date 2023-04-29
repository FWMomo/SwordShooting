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
    private int hp = 1;
    //UŒ‚Ši”[
    public GameObject enemyAtackPrefab;
    //UŒ‚ŠÔŠu
    private float atackTime = 0;
    //ƒJƒEƒ“ƒg
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
            atackTime += Time.deltaTime;
            if (atackTime >= 2.3 &&@count < 3)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                atackTime = 0;
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
