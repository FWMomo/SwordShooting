using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController2 : MonoBehaviour
{
    //�����ʒu
    private float deadLine = -20;
    //�ړ����x
    private float f = 1 / 1.3f;
    private float speedRate = -10;
    private float speedX = 0;
    private float speedY = 0;
    //�G�̗̑�
    private float hp = 3;
    //�K�E�Z�p;
    GameObject energy;
    //�K�E�Z�`���[�W��
    public int point = 2;
    //���̍U���͂��i�[
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;
    //�����ʒu�i�[�p
    public float positionX = 0;
    public float positionY = 0;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        energy = GameObject.Find("Energy");
        //���̍U���͂��擾
        knight = GameObject.Find("Knight");

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        speedX = speedRate * time;
        speedY = 2 * Mathf.Sin(2 * Mathf.PI * f * time);
        //�ړ����x
        this.transform.position = new Vector3(positionX + speedX, positionY + speedY, 0);
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

    public void Position(float positionX, float positionY)
    {
        this.positionX = positionX;
        this.positionY = positionY;
    }

    //�����̒e�Ƃ̐ڐG����
    void OnTriggerEnter2D(Collider2D other)
    {

        //KnightSword�ɐڐG�������̔���
        if (other.gameObject.tag == "KnightSwordTag")
        {
            //��e�̓x�U���͂𑪂�
            this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;

            this.hp -= this.knightSwordPower;
            Destroy(other.gameObject);
        }
        //KnightKnife�ɐڐG�������̔���
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            //��e�̓x�U���͂𑪂�
            this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;

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
