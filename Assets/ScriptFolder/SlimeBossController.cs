using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlimeBossController : MonoBehaviour
{
    //ƒNƒŠƒA‰æ–Ê
    GameObject clearText;
    GameObject pressEnterText;

    //Á‹ˆÊ’u
    private float deadLine = -20;

    //ˆÚ“®‘¬“x
    private float speed = -5;
    //“G‚Ì‘Ì—Í
    private float hp = 430;
    //UŒ‚Ši”[
    public GameObject enemyAtackPrefab2;

    //•KE‹Z—p
    GameObject energy;
    //•KE‹Zƒ`ƒƒ[ƒW—¦
    private int point = 15;
    //Œ•‚ÌUŒ‚—Í‚ğŠi”[
    public GameObject knight;
    private float knightSwordPower;
    private float knightKnifePower;

    // Start is called before the first frame update
    void Start()
    {
        clearText = GameObject.Find("ClearText");
        pressEnterText = GameObject.Find("PressEnterText");
        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");
        this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;
        this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
    }

    // Update is called once per frame
    void Update()
    {
        //ˆÚ“®‘¬“x
        transform.Translate(this.speed * Time.deltaTime, 0, 0);


        if (this.transform.position.x <= 14 && this.speed != 0)
        {
            StartCoroutine(AtackActivateCoroutine());
        }

        //‰æ–Ê’[‚Å”j‰ó
        if (this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    //UŒ‚‚ğÀs
    IEnumerator AtackActivateCoroutine()
    {
        do
        {
            this.speed = 0;
            StartCoroutine(AtackType1Coroutine());

            yield return new WaitForSeconds(8);

            StartCoroutine(AtackType2Coroutine());

            yield return new WaitForSeconds(12);

            for (int i = 0; i < 4; i++)
            {
                StartCoroutine(AtackType3Coroutine());
            }

            yield return new WaitForSeconds(12);

        }
        while (true) ;

    }

    //•úËŒ^‚ÌUŒ‚
    IEnumerator AtackType1Coroutine()
    {
        for(int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab2);
                EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                EnemyAtackPrefab.GetComponent<EnemyShotController2>().SetSpeed(-6, -8 + 2 * j + i % 2);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator AtackType2Coroutine()
    {

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab2);
                EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                EnemyAtackPrefab.GetComponent<EnemyShotController2>().SetSpeed(-6, 4 - j);
                yield return new WaitForSeconds(0.2f);
            }

            {
                for (int j = -1; j < 12; j++)
                {
                    GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab2);
                    EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                    EnemyAtackPrefab.GetComponent<EnemyShotController2>().SetSpeed(-6, -8 + j);
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
    }

    IEnumerator AtackType3Coroutine()
    {
        float random = 0;

        for (int i = 0; i < 6; i++)
        {
            random = Random.Range(-7, 7);
            for (int j = 0; j < 8; j++)
            {
                GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab2);
                EnemyAtackPrefab.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                EnemyAtackPrefab.GetComponent<EnemyShotController2>().SetSpeed(-6,random);
                yield return new WaitForSeconds(0.1f);          
            }
            yield return new WaitForSeconds(1);
        }
    }

    //–¡•û‚Ì’e‚Æ‚ÌÚG”»’è
    void OnTriggerEnter2D(Collider2D other)
    {
        //KnightSword‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightSwordTag")
        {
            //”í’e‚Ì“xUŒ‚—Í‚ğ‘ª‚é
            this.knightSwordPower = knight.GetComponent<KnightController>().knightSwordPower;

            this.hp -= this.knightSwordPower;
            Destroy(other.gameObject);
        }
        //KnightKnife‚ÉÚG‚µ‚½‚Ì”»’è
        if (other.gameObject.tag == "KnightKnifeTag")
        {
            //”í’e‚Ì“xUŒ‚—Í‚ğ‘ª‚é
            this.knightKnifePower = knight.GetComponent<KnightController>().knightKnifePower;
            this.hp -= this.knightKnifePower;
            Destroy(other.gameObject);
        }
        //HP‚ªƒ[ƒ‚É‚È‚Á‚½‚É‘ÎÛ‚ğÁ‚·
        if (hp <= 0)
        {
            knight.GetComponent<KnightController>().GameOver("GameClear!");
            Destroy(this.gameObject);
        }
    }

}


