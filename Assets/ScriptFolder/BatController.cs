using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    //ÁÊu
    private float deadLine = -20;

    //Ú®¬x
    private float speed = -6;
    //GÌÌÍ
    private int hp = 1;
    //Ui[
    public GameObject enemyAtackPrefab;
    //UÔu
    private float atackTime = 0;

    private bool isCalledOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ú®¬x
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        

        /*
        //U
        atackTime += Time.deltaTime;
        if (atackTime >= 3 && !isCalledOnce)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
            isCalledOnce = true;
        }
        */

        //æÊ[ÅÁ
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //¡ûÌeÆÌÚG»è
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //HPª[ÉÈÁ½ÉÎÛðÁ·
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
