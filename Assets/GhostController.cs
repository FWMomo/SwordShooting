using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    //ÁÊu
    private float deadLine = 25;

    //Ú®¬x
    private float speed = -5;
    //GÌÌÍ
    private int hp = 1;
    //Ui[
    public GameObject enemyAtackPrefab;
    //UÔu
    private float atackTime = 2.3f;
    //Ô
    private float time = 0;
    //JEg
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ú®¬x
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        if(this.transform.position.x <= 14)
        {
            this.speed = 0;
            //UOñJèÔ·
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

        //æÊ[ÅÁ
        if (this.transform.position.x > deadLine)
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
