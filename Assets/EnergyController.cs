using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    //エナジーチャージ量
    private float chargeRate = 0.267f;
    //KnightControllerを取得
    public GameObject knight;
    //現在のレベルを格納
    private int playerLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.Find("Knight");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //エネルギーをチャージ・必殺技発動
    public void EnergyCharger(int energy)
    {
        Debug.Log("yes");
        if(this.transform.position.x + chargeRate * energy >= 4)
        {
            //プレイヤーのレベルを上げて攻撃力を増加させる
            playerLevel++;
            knight.GetComponent<KnightController>().powerUpGradeRate = playerLevel;

            this.transform.position = new Vector2(-4, this.transform.position.y);

        }
        else
        {
            this.transform.position = new Vector2(this.transform.position.x + chargeRate * energy, this.transform.position.y);
        }
    }
}
