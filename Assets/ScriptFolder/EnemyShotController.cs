using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    GameObject knight;
    private float speed = -10;
    private float deadLine = -20;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.Find("Knight");

    }

    // Update is called once per frame
    void Update()
    {
        if(knight.GetComponent<KnightController>().hp <= 0)
        {
            Destroy(this.gameObject);
        }
        //ˆÚ“®‘¬“x
        transform.Translate(this.speed * Time.deltaTime, 0,0);
        //‰æ–Ê’[‚És‚Á‚½‚çÁ‹Ž
        if(this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }
}
