using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    //���̃I�u�W�F�N�g�Q�Ɨp
    public GameObject energy;
    public GameObject knight;

    //UI���i�[
    public GameObject uIPower;
    public GameObject uILevel;
    public GameObject uIEnemyStats;
    public GameObject uILife;

    //�c�@
    public int life = 0;
    public int level = 0;
    public int power = 0;

    // Start is called before the first frame update
    void Start()
    {

        //���[�ނ��Ԃ������Ɠǂݍ���
        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");

        //�����X�e�[�^�X�ǂݍ���
        level = energy.GetComponent<EnergyController>().playerLevel;
        power = knight.GetComponent<KnightController>().knightSwordPower;
        life = knight.GetComponent<KnightController>().life;

        //�����X�e�[�^�X�\��
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
