using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : MonoBehaviour
{
    //消去位置
    private float deadLine = -20;
    //移動速度
    private float speedX = -6;
    private float speedY = 1;
    //敵の体力
    private int hp = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            //移動速度);
            this.transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        //画面端で消去
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //味方の弾との接触判定
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //HPがゼロになった時に対象を消す
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
