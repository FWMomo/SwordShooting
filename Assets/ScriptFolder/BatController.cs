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
    private int hp = 1;
    //�U���i�[
    public GameObject enemyAtackPrefab;
    //�U���Ԋu
    private float atackTime = 0;

    private bool isCalledOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ����x
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        

        /*
        //�U��
        atackTime += Time.deltaTime;
        if (atackTime >= 3 && !isCalledOnce)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
            isCalledOnce = true;
        }
        */

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
