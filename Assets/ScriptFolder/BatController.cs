using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    //è¡ãéà íu
    private float deadLine = -20;

    //à⁄ìÆë¨ìx
    private float speed = -6;
    //ìGÇÃëÃóÕ
    private int hp = 1;
    //çUåÇäiî[
    public GameObject enemyAtackPrefab;
    //çUåÇä‘äu
    private float atackTime = 0;

    private bool isCalledOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //à⁄ìÆë¨ìx
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        

        /*
        //çUåÇ
        atackTime += Time.deltaTime;
        if (atackTime >= 3 && !isCalledOnce)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
            isCalledOnce = true;
        }
        */

        //âÊñ í[Ç≈è¡ãé
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //ñ°ï˚ÇÃíeÇ∆ÇÃê⁄êGîªíË
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //HPÇ™É[ÉçÇ…Ç»Ç¡ÇΩéûÇ…ëŒè€Çè¡Ç∑
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
