using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController2 : MonoBehaviour
{
    private float speed = -10;
    private float deadLine = -20;
    public float numY = 0;
    public float speedY = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //移動速度
        transform.Translate(this.speed * Time.deltaTime, this.speedY * Time.deltaTime , 0);
        //画面端に行ったら消去
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }
    public void SetY(float speedY)
    {
        this.speedY = speedY;
    }

}
