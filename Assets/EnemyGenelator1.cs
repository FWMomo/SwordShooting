using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenelator1 : MonoBehaviour
{
    //���Ԋi�[
    private float time = 0;
    //�J�E���g�p
    private int count = 0;

    //�v���n�u�i�[
    public GameObject batPrefab;
    public GameObject ghostPrefab;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //time�Ŏ��Ԃ𑪂�
        time += Time.deltaTime;
        //�G����

        //Bat���ܑ̐���
        if (time >= 0 && count == 0)
        {
            Debug.Log(1);
            for(int i = 0; i < 5; i++)
            {
            GameObject BatPrefab = Instantiate(batPrefab);
            Debug.Log(2);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
            }
            count++;
        }

        //Bat���ܑ̐���
        if (time >= 5 && count == 1)
        {
            Debug.Log(1);
            for (int i = 0; i < 5; i++)
            {
                GameObject BatPrefab = Instantiate(batPrefab);
                Debug.Log(2);
                BatPrefab.transform.position = new Vector2(20 + i * 2, 4);
            }
            count++;
        }

        //Ghost���̐���
        if (time >= 10 && count == 2)
        {
            Debug.Log(1);
            for (int i = 0; i < 2; i++)
            {
                GameObject GhostPrefab = Instantiate(ghostPrefab);
                Debug.Log(2);
                GhostPrefab.transform.position = new Vector2(20, -4 - 4 * i);
            }
            count++;
        }





    }
}
