using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : MonoBehaviour
{
    //è¡ãéà íu
    private float deadLine = -20;
    //à⁄ìÆë¨ìx
    private float speedX = -6;
    private float speedY = 1;
    //ìGÇÃëÃóÕ
    private int hp = 1;
    //íeÉvÉåÉnÉu
    public GameObject enemyAtackPrefab;
    //çUåÇä‘äu
    private float atackTime = 4f;
    //éûä‘
    private float time = 0;
    //èâåÇÇ‹Ç≈ÇÃéûä‘
    private float firstAtackTime = 0.4f;

    //ïKéEãZóp
    GameObject energy;
    //ïKéEãZÉ`ÉÉÅ[ÉWó¶
    private int point = 1;

    // Start is called before the first frame update
    void Start()
    {
        //èâåÇÇ‹Ç≈ÇÃéûä‘
        firstAtackTime += atackTime;

        energy = GameObject.Find("Energy");
    }

    // Update is called once per frame
    void Update()
    {
        //çUåÇ
        time += Time.deltaTime;
        if (time >= atackTime - firstAtackTime)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab);
            EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            time = 0;
            firstAtackTime = 0;
        }

        //à⁄ìÆ
        this.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        //âÊñ í[Ç≈è¡ãé
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //ñ°ï˚ÇÃíeÇ∆ÇÃê⁄êGîªíË
    void OnTriggerEnter2D(Collider2D other)
    {
        //KnightSwordÇ…ê⁄êGÇµÇΩéûÇÃîªíË
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //KnightKnifeÇ…ê⁄êGÇµÇΩéûÇÃîªíË
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //HPÇ™É[ÉçÇ…Ç»Ç¡ÇΩéûÇ…ëŒè€Çè¡Ç∑
        if (hp <= 0)
        {
            energy.GetComponent<EnergyController>().EnergyCharger(point);
            Destroy(this.gameObject);
        }
    }
}
