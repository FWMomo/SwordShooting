using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyController : MonoBehaviour
{
    //エナジーチャージ量
    private float chargeRate = 0.5f;
    //KnightControllerを取得
    public GameObject knight;
    //現在のレベルを格納
    public int playerLevel = 1;

    public GameObject uIController;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.Find("Knight");
        uIController = GameObject.Find("UIController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //エネルギーをチャージ・必殺技発動
    public void EnergyCharger(float energy)
    {
        Debug.Log(energy);
        if (this.transform.position.x + chargeRate * energy >= 4)
        {
            //プレイヤーのレベルを上げて攻撃力を増加させる
            knight.GetComponent<KnightController>().powerUpGradeRate += 0.1f;
            playerLevel++;
            levelText.text = "Level : " + playerLevel.ToString();
            energy = transform.position.x - chargeRate * energy;
            this.transform.position = new Vector2(-4 + transform.position.x -energy, this.transform.position.y);
            uIController.GetComponent<UIController>().weaponChecker = true;

        }
        else
        {
            this.transform.position = new Vector2(this.transform.position.x + chargeRate * energy, this.transform.position.y);
        }
    }
}
