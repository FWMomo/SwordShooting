using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    //�����ʒu
    private float deadLine = -20;
    //�ړ����x
    private float speed = -6;
    //�G�̗̑�
    private int hp = 2;
    //�K�E�Z�p;
    GameObject energy;
    //�K�E�Z�`���[�W��
    private int point = 1;
    //KnightController���猻�݂̍U���͂��擾���邽��
    GameObject knight;
    private int knightSwordPower;
    private int knightKnifePower;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.Find("Energy");
        //���̍U���͂��擾
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;

    }

    // Update is called once per frame
    void Update()
    {
        //�ړ����x
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʒ[�ŏ���
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
        //HP���[���ɂȂ������ɑΏۂ�����
        if (hp <= 0)
        {
            energy.GetComponent<EnergyController>().EnergyCharger(point);
            Destroy(this.gameObject);
        }
    }

    //�����̒e�Ƃ̐ڐG����
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //KnightSword�ɐڐG�������̔���
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= this.knightSwordPower;
            Destroy(other.gameObject);
        }
        //KnightKnife�ɐڐG�������̔���
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            this.hp -= this.knightKnifePower;
            Destroy(other.gameObject);
        }
        //HP���[���ɂȂ������ɑΏۂ�����
        if (hp <= 0)
        {
            energy.GetComponent<EnergyController>().EnergyCharger(point);
            Destroy(this.gameObject);
        }
        
    }

}
