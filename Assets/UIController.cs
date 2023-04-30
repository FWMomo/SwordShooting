using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    //他のオブジェクト参照用
    public GameObject energy;
    public GameObject knight;

    //UIを格納
    public GameObject uIPower;
    public GameObject uILevel;
    public GameObject uIEnemyStats;
    public GameObject uILife;

    //残機
    public int life = 0;
    public int level = 0;
    public int power = 0;

    // Start is called before the first frame update
    void Start()
    {

        //げーむおぶじぇくと読み込み
        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");

        //初期ステータス読み込み
        level = energy.GetComponent<EnergyController>().playerLevel;
        power = knight.GetComponent<KnightController>().knightSwordPower;
        life = knight.GetComponent<KnightController>().life;

        //初期ステータス表示
        uIPower = GameObject.Find ("UIPower");
        uIPower.GetComponent<Text>().text = "Power" + power;

        uILevel = GameObject.Find("UILevel");
        uILevel.GetComponent<Text>().text = "Level" + level;

        uILevel = GameObject.Find("UILife");
        uILevel.GetComponent<Text>().text = "*" + life;

    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
