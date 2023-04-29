using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeController : MonoBehaviour
{
    //�����ʒu
    private float deadLine = -20;
    //�ړ����x
    private float speedX = -6;
    private float speedY = 10;
    //�G�̗̑�
    private int hp = 1;
    //����
    private float time = 0; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //�ړ����x
        this.transform.position = new Vector2(0,Mathf.Sin(Time.deltaTime * speedY));
        this.transform.Translate(speedX, 0,0);
        //��ʒ[�ŏ���
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //�����̒e�Ƃ̐ڐG����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //HP���[���ɂȂ������ɑΏۂ�����
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
