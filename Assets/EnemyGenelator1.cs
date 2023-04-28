using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenelator1 : MonoBehaviour
{
    //時間格納
    private float time = 0;
    //カウント用
    private int count = 0;

    //プレハブ格納
    public GameObject batPrefab;
    public GameObject ghostPrefab;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //timeで時間を測る
        time += Time.deltaTime;
        //敵生成

        //Batを五体生成
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

        //Batを五体生成
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

        //Ghostを二体生成
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
