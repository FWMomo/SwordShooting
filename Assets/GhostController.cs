using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    //�����ʒu
    private float deadLine = 25;

    //�ړ����x
    private float speed = -5;
    //�G�̗̑�
    private float hp = 3;
    //�U���i�[
    public GameObject enemyAtackPrefab;
    //�U���Ԋu
    private float atackTime = 2.3f;
    //����
    private float time = 0;
    //�J�E���g
    int count = 0;

    //�K�E�Z�p
    GameObject energy;
    //�K�E�Z�`���[�W��
    private int point = 2;
    //���̍U���͂��i�[
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;

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

        if(this.transform.position.x <= 14)
        {
            this.speed = 0;
            //�U���O��J��Ԃ�
            time += Time.deltaTime;
            if (time >= atackTime &&�@count < 3)
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

        //��ʒ[�ŏ���
        if (this.transform.position.x > deadLine)
        {
            Destroy(gameObject);
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
