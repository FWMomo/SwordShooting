using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KnightController : MonoBehaviour
{
    GameObject uIController;


    public bool isGameOver = false;
    //audio
    public AudioSource audioSE;
    public AudioClip a1;
    public AudioClip a2;


    private Rigidbody2D myRigidbody;
    //���Ԏ擾
    private float time = 0;
    //HP�ݒ�
    public int hp = 1;
    //�ړ����x
    private float velocity = 10F;
    //����Ɉړ����x������
    private float velocityX = 0;
    private float velocityY = 0;
    //�U���͑�������
    public float powerUpGradeRate = 0;

    //�e�ۂ̃v���n�u�ݒ�

    //�e�ۂ̍쐬

    //���З́E�჌�[�g�E�����蔻���
    public GameObject knightSwordPrefab;
    //�U�����x
    private float knightSwordAtackTime = 0.35f;
    //�e�ۂ̑��x
    private float knightSwordVelocityX = 20;
    //�e�ۂ̍U����
    public float knightSwordPower = 2;

    //��З́E�����[�g�E�����蔻�菬
    public GameObject knightKnifePrefab;
    //�U�����x
    private float knightKnifeAtackTime = 0.1f;
    //�e�ۂ̑��x
    private float knightKnifeVelocityX = 40;
    //�e�ۂ̍U����
    public float knightKnifePower = 1;

    //�������Ă��镐��̎�ޗp
    public int weaponType = 0;

    //GameOver�p�̃e�L�X�g
    GameObject gameOverText;


    //�A�C�e���p
    public bool knightSword = true;
    public bool knightKnife = false;

    // Start is called before the first frame update
    void Start()
    {

        this.myRigidbody = GetComponent<Rigidbody2D>();
        gameOverText = GameObject.Find("GameOverText");

        uIController = GameObject.Find("UIController");
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        this.myRigidbody.velocity = new Vector2(velocityX, velocityY);
        /*
        //��ʒ[�ɓ��B�����瑬�x�O�ɂ���
        if(this.transform.position.x >= 17 && velocityX >= 0)
        {
            velocityX = 0;
        }
        if (this.transform.position.x <= -17 && velocityX <= 0)
        {
            velocityX = 0;
        }
        
        if (this.transform.position.y >= 9.5 && velocityY >= 0)
        {
            velocityY = 0;
        }
        if (this.transform.position.y <= -6 && velocityY <= 0)
        {
            velocityY = 0;
        }
        */
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
            knightSwordPower = 2 + (2 * powerUpGradeRate);
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
            knightKnifePower = 1 + (1 * powerUpGradeRate);
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

        if (hp <= 0 && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("yes");
            SceneManager.LoadScene("TitleScene");

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
            weaponType = 0;
            uIController.GetComponent<UIController>().weaponChecker = true;
            Destroy(other.gameObject);

        }

        //KnightKnife�擾
        if (other.gameObject.tag == "ItemKnightKnifeTag")
        {
            this.knightSword = false;
            this.knightKnife = true;
            weaponType = 1;
            uIController.GetComponent<UIController>().weaponChecker = true;
            Destroy(other.gameObject);
        }

        if (hp <= 0 && !isGameOver)
        {

            gameOverText.GetComponent<Text>().text = "GameOver";
            this.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
            isGameOver = false;
        }
    }
}
