using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    //���Ԏ擾
    private float time = 0;
    //HP�ݒ�
    private int hp = 1;
    //�c�@
    public int life = 1;
    //�ړ����x
    private float velocity = 6F;
    //����Ɉړ����x������
    private float velocityX = 0;
    private float velocityY = 0;
    //�U���͑�������
    public int powerUpGradeRate = 1;

    //�e�ۂ̃v���n�u�ݒ�

    //�e�ۂ̍쐬

    //���З́E�჌�[�g�E�����蔻���
    public GameObject knightSwordPrefab;
    //�U�����x
    private float knightSwordAtackTime = 0.3f;
    //�e�ۂ̑��x
    private float knightSwordVelocityX = 20;
    //�e�ۂ̍U����
    public int knightSwordPower = 3;

    //��З́E�����[�g�E�����蔻�菬
    public GameObject knightKnifePrefab;
    //�U�����x
    private float knightKnifeAtackTime = 0.1f;
    //�e�ۂ̑��x
    public float knightKnifeVelocityX = 40;
    //�e�ۂ̍U����
    public int knightKnifePower = 1;



    //GameOver�p�̃e�L�X�g
    GameObject gameOverText;


    //�A�C�e���p
    public bool knightSword = true;
    public bool knightKnife = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(life);
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

        //KnightSword
        if (knightSword && Input.GetMouseButton(0) && time >= knightSwordAtackTime)
        {
            //�����тɃp���[���A�b�v�f�[�g
            knightSwordPower = 3 * powerUpGradeRate;
            //�e�̐���
            GameObject KnightSword = Instantiate(knightSwordPrefab);
            //�e�̏o���ʒu�̒���
            KnightSword.transform.position = new Vector2(this.gameObject.transform.position.x + 0.4f, this.gameObject.transform.position.y - 0.5f);
            //�e�ɑ��x��^����
            KnightSword.GetComponent<Rigidbody2D>().velocity = new Vector2(knightSwordVelocityX, 0);
            //time�����Z�b�g
            time = 0;
        }
        //KnightKnife
        else if (knightKnife && Input.GetMouseButton(0) && time >= knightKnifeAtackTime)
        {
            //�����тɃp���[���A�b�v�f�[�g
            knightKnifePower = 1 * powerUpGradeRate;
            Debug.Log(knightKnifePower);
            //�e�̐���
            GameObject KnightKnife = Instantiate(knightKnifePrefab);
            //�e�̏o���ʒu�̒���
            KnightKnife.transform.position = new Vector2(this.gameObject.transform.position.x + 0.4f, this.gameObject.transform.position.y - 0.5f);
            //�e�ɑ��x��^����
            KnightKnife.GetComponent<Rigidbody2D>().velocity = new Vector2(knightKnifeVelocityX, 0);
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

        //�A�C�e���擾

        //KnightSword�擾
        if (other.gameObject.tag == "ItemKnightSwordTag")
        {
            this.knightSword = true;
            this.knightKnife = false;
            Destroy(other.gameObject);
        }

        //KnightKnife�擾
        if (other.gameObject.tag == "ItemKnightKnifeTag")
        {
            this.knightSword = false;
            this.knightKnife = true;
            Destroy(other.gameObject);
        }

        if (hp <= 0)
        {
            life--;
            Destroy(this.gameObject);
            gameOverText.GetComponent<Text>().text = "GameOver";
        }
    }
}