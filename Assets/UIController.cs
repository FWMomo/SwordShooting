using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public bool weaponChecker = false;
    //���̃I�u�W�F�N�g�Q�Ɨp
    public GameObject energy;
    public GameObject knight;

    //UI���i�[
    public GameObject uIPower;
    public GameObject uILevel;
    public GameObject uIKnightSword;
    public GameObject uIKnightKnife;

    //�c�@
    public int level = 0;
    public float power = 0;

    int weaponType = 0;

    // Start is called before the first frame update
    void Start()
    {

        //GameObject�ǂݍ���
        energy = GameObject.Find("Energy");
        knight = GameObject.Find("Knight");

        uIKnightSword = GameObject.Find("UIKnightSword");
        uIKnightKnife = GameObject.Find("UIKnightKnife");
        uIKnightKnife.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);

        //�����X�e�[�^�X�ǂݍ���
        level = energy.GetComponent<EnergyController>().playerLevel;
        power = knight.GetComponent<KnightController>().knightSwordPower;

        //�����X�e�[�^�X�\��
        uIPower = GameObject.Find ("UIPower");
        uIPower.GetComponent<Text>().text = "Power" + power;

        uILevel = GameObject.Find("UILevel");
        uILevel.GetComponent<Text>().text = "Level" + level;
        //���݂̃p���[���i�[

    }
    
    // Update is called once per frame
    void Update()
    {
        if (weaponChecker)
        {
            //�X�V��X�e�[�^�X�\��
            this.weaponType = knight.GetComponent<KnightController>().weaponType;
            if(this.weaponType == 0)
            {
                power =2 + 2 * knight.GetComponent<KnightController>().powerUpGradeRate;
                //�������Ă��錕��\��

                uIKnightSword.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
                uIKnightKnife.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
            }
            else if(this.weaponType == 1)
            {
                power =1 + 1 * knight.GetComponent<KnightController>().powerUpGradeRate;
                //�������Ă��錕��\��

                uIKnightSword.GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
                uIKnightKnife.GetComponent<SpriteRenderer>().material.color = new Color32(255, 255, 255, 255);
            }
            uIPower.GetComponent<Text>().text = "Power" + power;
            weaponChecker = false;
        }
    }
}
