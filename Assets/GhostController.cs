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
    private int hp = 1;
    //�U���i�[
    public GameObject enemyAtackPrefab;
    //�U���Ԋu
    private float atackTime = 0;
    //�J�E���g
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
            atackTime += Time.deltaTime;
            if (atackTime >= 2.3 &&�@count < 3)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                atackTime = 0;
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
