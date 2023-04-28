using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBossController : MonoBehaviour
{
    //ƒeƒLƒXƒgŠi”[
    private GameObject clearText;
    //“G‚Ì‘Ì—Í
    private int hp = 10;
    //UŒ‚‚Ì•\¦
    public GameObject enemyAtackPrefab;
    //UŒ‚ŠÔŠu
    private float atackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        clearText = GameObject.Find("ClearText");
    }

    // Update is called once per frame
    void Update()
    {
        //UŒ‚
        atackTime += Time.deltaTime;
        if (atackTime >= 2)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, Vector2.zero, Quaternion.identity);
            //UŒ‚ŠÔŠu
            atackTime -= 2;
        }
        

    }
    //–¡•û‚Ì’e‚Æ‚ÌÚG”»’è
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Debug.Log(this.hp);
            Destroy(other.gameObject);
        }
        //HP‚ªƒ[ƒ‚É‚È‚Á‚½‚É‘ÎÛ‚ğÁ‚·
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            //ƒ{ƒX‚ğ“|‚µ‚ÄƒQ[ƒ€ƒNƒŠƒA[
            this.clearText.GetComponent<Text>().text = "GameClear!!";
        }    
    }

}


