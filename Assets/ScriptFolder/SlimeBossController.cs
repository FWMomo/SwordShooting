using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeBossController : MonoBehaviour
{
    //�e�L�X�g�i�[
    private GameObject clearText;
    //�G�̗̑�
    private int hp = 10;
    //�U���̕\��
    public GameObject enemyAtackPrefab;
    //�U���Ԋu
    private float atackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        clearText = GameObject.Find("ClearText");
    }

    // Update is called once per frame
    void Update()
    {
        //�U��
        atackTime += Time.deltaTime;
        if (atackTime >= 2)
        {
            GameObject EnemyAtackPrefab = Instantiate(enemyAtackPrefab, Vector2.zero, Quaternion.identity);
            //�U���Ԋu
            atackTime -= 2;
        }
        

    }
    //�����̒e�Ƃ̐ڐG����
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "KnightSwordTag")
        {
            this.hp -= 1;
            Debug.Log(this.hp);
            Destroy(other.gameObject);
        }
        //HP���[���ɂȂ������ɑΏۂ�����
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            //�{�X��|���ăQ�[���N���A�[
            this.clearText.GetComponent<Text>().text = "GameClear!!";
        }    
    }

}


