using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnigtController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    //���Ԏ擾
    private float time = 0;
    //�U�����x
    private float atackTime = 0.5f;
    //HP�ݒ�
    private int hp = 1;
    //�ړ����x
    private float velocity = 6F;
    //����Ɉړ����x������
    private float velocityX = 0;
    private float velocityY = 0;

    //�e�ۂ̃v���n�u�ݒ�

    //�e�ۂ̍쐬
    public GameObject knightSwordPrefab;
    //�e�ۂ̑��x
    public float knightSwordVelocityX = 40;

    //GameOver�p�̃e�L�X�g
    GameObject gameOverText;


    //�A�C�e���p

    //AtackTimeUpGrader�̍U�����x�㏸��
    float atackTimeUpGradeRate = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody = GetComponent<Rigidbody2D>();
        gameOverText = GameObject.Find("GameOverText");

    }

    // Update is called once per frame
    void Update()
    {

        //�ړ�
        this.myRigidbody.velocity = new Vector2(velocityX, velocityY);
  
        //�E�ړ�
        if (Input.GetKeyDown(KeyCode.D))
        {
            velocityX += velocity;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            velocityX -= velocity;
        }

        //���ړ�
        if (Input.GetKeyDown(KeyCode.A))
        {
            velocityX -= velocity;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            velocityX += velocity;
        }

        //��ړ�
        if (Input.GetKeyDown(KeyCode.W))
        {
            velocityY += velocity;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            velocityY -= velocity;
        }
        //���ړ�
        if (Input.GetKeyDown(KeyCode.S))
        {
            velocityY -= velocity;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            velocityY += velocity;
        }

        //�U��
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && time >= atackTime)
        {
            //�e�̐���
            GameObject KnightSword = Instantiate(knightSwordPrefab);
            //�e�̏o���ʒu�̒���
            KnightSword.transform.position = new Vector2(this.gameObject.transform.position.x + 0.4f, this.gameObject.transform.position.y - 0.5f);
            //�e�ɑ��x��^����
            KnightSword.GetComponent<Rigidbody2D>().velocity = new Vector2(knightSwordVelocityX,0);
            //time�����Z�b�g
            time = 0;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //�G�̒e�ɏՓ�
        if (other.gameObject.tag == "EnemyShotTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }
        //�U�����x�㏸�ɏՓ�
        if (other.gameObject.tag == "AtackTimeUpGraderTag")
        {
            this.atackTime *= atackTimeUpGradeRate;
            Destroy(other.gameObject);
            Debug.Log(atackTime);
        }

        //HP���[���ɂȂ������ɑΏۂ�����
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            gameOverText.GetComponent<Text>().text = "GameOver";
        }
    }



}
