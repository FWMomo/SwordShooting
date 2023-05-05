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
    //時間取得
    private float time = 0;
    //HP設定
    public int hp = 1;
    //移動速度
    private float velocity = 10F;
    //これに移動速度を入れる
    private float velocityX = 0;
    private float velocityY = 0;
    //攻撃力増加割合
    public float powerUpGradeRate = 0;

    //弾丸のプレハブ設定

    //弾丸の作成

    //高威力・低レート・当たり判定大
    public GameObject knightSwordPrefab;
    //攻撃速度
    private float knightSwordAtackTime = 0.35f;
    //弾丸の速度
    private float knightSwordVelocityX = 20;
    //弾丸の攻撃力
    public float knightSwordPower = 2;

    //低威力・高レート・当たり判定小
    public GameObject knightKnifePrefab;
    //攻撃速度
    private float knightKnifeAtackTime = 0.1f;
    //弾丸の速度
    private float knightKnifeVelocityX = 40;
    //弾丸の攻撃力
    public float knightKnifePower = 1;

    //装備している武器の種類用
    public int weaponType = 0;

    //GameOver用のテキスト
    GameObject gameOverText;


    //アイテム用
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
        //移動
        this.myRigidbody.velocity = new Vector2(velocityX, velocityY);
        /*
        //画面端に到達したら速度０にする
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
        //右移動
        if (Input.GetKeyDown(KeyCode.D))
        {
            velocityX += velocity;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
                velocityX -= velocity;
        }

        //左移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            velocityX -= velocity;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
                velocityX += velocity;
        }

        //上移動
        if (Input.GetKeyDown(KeyCode.W))
        {
            velocityY += velocity;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
                velocityY -= velocity;
        }
        //下移動
        if (Input.GetKeyDown(KeyCode.S))
        {
            velocityY -= velocity;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
                velocityY += velocity;
        }

        //攻撃
        time += Time.deltaTime;

        //KnightSword
        if (knightSword && Input.GetMouseButton(0) && time >= knightSwordAtackTime)
        {
            //撃つたびにパワーをアップデート
            knightSwordPower = 2 + (2 * powerUpGradeRate);
            //弾の生成
            GameObject KnightSword = Instantiate(knightSwordPrefab);
            //弾の出現位置の調整
            KnightSword.transform.position = new Vector2(this.gameObject.transform.position.x + 0.4f, this.gameObject.transform.position.y - 0.5f);
            //弾に速度を与える
            KnightSword.GetComponent<Rigidbody2D>().velocity = new Vector2(knightSwordVelocityX, 0);
            //timeをリセット
            time = 0;
        }
        //KnightKnife
        else if (knightKnife && Input.GetMouseButton(0) && time >= knightKnifeAtackTime)
        {
            //撃つたびにパワーをアップデート
            knightKnifePower = 1 + (1 * powerUpGradeRate);
            Debug.Log(knightKnifePower);
            //弾の生成
            GameObject KnightKnife = Instantiate(knightKnifePrefab);
            //弾の出現位置の調整
            KnightKnife.transform.position = new Vector2(this.gameObject.transform.position.x + 0.4f, this.gameObject.transform.position.y - 0.5f);
            //弾に速度を与える
            KnightKnife.GetComponent<Rigidbody2D>().velocity = new Vector2(knightKnifeVelocityX, 0);
            //timeをリセット
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
        //敵の弾に衝突
        if (other.gameObject.tag == "EnemyShotTag")
        {
            this.hp -= 1;
            Destroy(other.gameObject);
        }

        //アイテム取得

        //KnightSword取得
        if (other.gameObject.tag == "ItemKnightSwordTag")
        {
            this.knightSword = true;
            this.knightKnife = false;
            weaponType = 0;
            uIController.GetComponent<UIController>().weaponChecker = true;
            Destroy(other.gameObject);

        }

        //KnightKnife取得
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
