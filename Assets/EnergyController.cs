using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyController : MonoBehaviour
{
    //�G�i�W�[�`���[�W��
    private float chargeRate = 0.5f;
    //KnightController���擾
    public GameObject knight;
    //���݂̃��x�����i�[
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

    //�G�l���M�[���`���[�W�E�K�E�Z����
    public void EnergyCharger(float energy)
    {
        Debug.Log(energy);
        if (this.transform.position.x + chargeRate * energy >= 4)
        {
            //�v���C���[�̃��x�����グ�čU���͂𑝉�������
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
