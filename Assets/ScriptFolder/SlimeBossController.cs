using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBossController : MonoBehaviour
{
    //テキスト格納
    private GameObject clearText;
    //敵の体力
    private int hp = 10;
    //攻撃の表示
    public GameObject enemyAtackPrefab;
    //攻撃間隔
    private float atackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        clearText = GameObject.Find("ClearText");
    }

    // Update is called once per frame
    void Update()
    {
        //攻撃
        atackTime += Time.deltaTime;
        if (atackTime >= 2)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, Vector2.zero, Quaternion.identity);
            //攻撃間隔
            atackTime -= 2;
        }
        

    }
    //味方の弾との接触判定
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Debug.Log(this.hp);
            Destroy(other.gameObject);
        }
        //HPがゼロになった時に対象を消す
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            //ボスを倒してゲームクリアー
            this.clearText.GetComponent<Text>().text = "GameClear!!";
        }    
    }

}


