using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    //�G�i�W�[�`���[�W��
    private float chargeRate = 0.267f;
    //KnightController���擾
    public GameObject knight;
    //���݂̃��x�����i�[
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

    //�G�l���M�[���`���[�W�E�K�E�Z����
    public void EnergyCharger(int energy)
    {
        Debug.Log("yes");
        if(this.transform.position.x + chargeRate * energy >= 4)
        {
            //�v���C���[�̃��x�����グ�čU���͂𑝉�������
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
