using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnigtController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    //時間取得
    private float time = 0;
    //攻撃速度
    private float atackTime = 0.5f;
    //HP設定
    private int hp = 1;
    //移動速度
    private float velocity = 6F;
    //これに移動速度を入れる
    private float velocityX = 0;
    private float velocityY = 0;

    //弾丸のプレハブ設定

    //弾丸の作成
    public GameObject knightSwordPrefab;
    //弾丸の速度
    public float knightSwordVelocityX = 40;

    //GameOver用のテキスト
    GameObject gameOverText;


    //アイテム用

    //AtackTimeUpGraderの攻撃速度上昇率
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

        //移動
        this.myRigidbody.velocity = new Vector2(velocityX, velocityY);
  
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
        if (Input.GetMouseButtonDown(0) && time >= atackTime)
        {
            //弾の生成
            GameObject KnightSword = Instantiate(knightSwordPrefab);
            //弾の出現位置の調整
            KnightSword.transform.position = new Vector2(this.gameObject.transform.position.x + 0.4f, this.gameObject.transform.position.y - 0.5f);
            //弾に速度を与える
            KnightSword.GetComponent<Rigidbody2D>().velocity = new Vector2(knightSwordVelocityX,0);
            //timeをリセット
            time = 0;
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
        //攻撃速度上昇に衝突
        if (other.gameObject.tag == "AtackTimeUpGraderTag")
        {
            this.atackTime *= atackTimeUpGradeRate;
            Destroy(other.gameObject);
            Debug.Log(atackTime);
        }

        //HPがゼロになった時に対象を消す
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            gameOverText.GetComponent<Text>().text = "GameOver";
        }
    }



}
