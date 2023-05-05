using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController2 : MonoBehaviour
{
    GameObject knight;
    public float speedX = 0;
    private float deadLine = -20;
    public float numY = 0;
    public float speedY = 0;
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.Find("Knight");
    }

    // Update is called once per frame
    void Update()
    {
        if (knight.GetComponent<KnightController>().hp <= 0)
        {
            Destroy(this.gameObject);
        }
        //ˆÚ“®‘¬“x
        transform.Translate(this.speedX * Time.deltaTime, this.speedY * Time.deltaTime , 0);
        //‰æ–Ê’[‚És‚Á‚½‚çÁ‹Ž
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //‚™Ž²‚ÌŒX‚«‚ðŒˆ’è
    public void SetSpeed(float speedX, float speedY)
    {
        this.speedX = speedX;
        this.speedY = speedY;
    }

}
