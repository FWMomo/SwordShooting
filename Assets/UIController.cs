using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public bool weaponChecker = false;
    //他のオブジェクト参照用
    public GameObject energy;
    public GameObject knight;

    //UIを格納
    public GameObject uIPower;
    public GameObject uILevel;
    public GameObject uIKnightSword;
    public GameObject uIKnightKnife;

    //残機
    public int level = 0;
    public float power = 0;

    int weaponType = 0;

    // Start is called before the first frame update
    void Start()
    {

        //GameObject読み込み
        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");

        uIKnightSword = GameObject.Find("UIKnightSword");
        uIKnightKnife = GameObject.Find("UIKnightKnife");
        uIKnightKnife.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);

        //初期ステータス読み込み
        level = energy.GetComponent<EnergyController>().playerLevel;
        power = knight.GetComponent<KnightController>().knightSwordPower;

        //初期ステータス表示
        uIPower = GameObject.Find ("UIPower");
        uIPower.GetComponent<Text>().text = "Power" + power;

        uILevel = GameObject.Find("UILevel");
        uILevel.GetComponent<Text>().text = "Level" + level;
        //現在のパワーを格納

    }
    
    // Update is called once per frame
    void Update()
    {
        if (weaponChecker)
        {
            //更新後ステータス表示
            this.weaponType = knight.GetComponent<KnightController>().weaponType;
            if(this.weaponType == 0)
            {
                power =2 + 2 * knight.GetComponent<KnightController>().powerUpGradeRate;
                //装備している剣を表示

                uIKnightSword.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
                uIKnightKnife.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
            }
            else if(this.weaponType == 1)
            {
                power =1 + 1 * knight.GetComponent<KnightController>().powerUpGradeRate;
                //装備している剣を表示

                uIKnightSword.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
                uIKnightKnife.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
            }
            uIPower.GetComponent<Text>().text = "Power" + power;
            weaponChecker = false;
        }
    }
}
