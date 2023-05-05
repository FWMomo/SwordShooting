using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye2Controller : MonoBehaviour
{
    //�����ʒu
    private float deadLine = -20;
    //�ړ����x
    private float speedX = -6;
    private float speedY = 1;
    //�G�̗̑�
    private float hp = 2;
    //�e�v���n�u
    public GameObject enemyAtackPrefab;
    //�����܂ł̎���
    private float firstAtackTime = 0.4f;


    GameObject energy;
    //�K�E�Z�`���[�W��
    private int point = 1;
    //���̍U���͂��i�[
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Atack());

        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        this.transform.Translate(speedX * Time.deltaTime, 0, 0);

        //��ʒ[�ŏ���
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Atack()
    {
        yield return new WaitForSeconds(firstAtackTime);
        for (int i = 0; i < 5; i++)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab);
            EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            EnemyAtackPrefab.GetComponent<EnemyShotController2>().SetSpeed(-10, -2);
            yield return new WaitForSeconds(3);
        }
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

