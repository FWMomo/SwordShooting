using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenelator : MonoBehaviour
{
    //プレハブ格納
    public GameObject batPrefab;
    public GameObject ghostPrefab;
    public GameObject flyEyePrefab;
    public GameObject ghostPrefab2;
    public GameObject skeltonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Genelate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Genelate()
    {
        //Batを五体生成
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 4);
        }
        yield return new WaitForSeconds(4);

        //Batを五体生成
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(4);

        //Batを五体生成
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, -4);
        }
        yield return new WaitForSeconds(4);

        //FlyEyeを二体生成
        for (int i = 0; i < 3; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 2, 2 - 4 * i);
        }
        yield return new WaitForSeconds(3);

        //Ghost2を3体生成
        for (int i = 0; i < 3; i++)
        {
            GameObject GhostPrefab2 = Instantiate(ghostPrefab2);
            GhostPrefab2.transform.position = new Vector2(20 + i * 3,0);
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(3);

        //skeltonを一体生成
        GameObject SkeltonPrefab = Instantiate(skeltonPrefab);
        SkeltonPrefab.transform.position = new Vector2(23,-2);
        yield return new WaitForSeconds(3);
        /*
         * //Ghostを二体生成
        for (int i = 0; i < 2; i++)
        {
            GameObject GhostPrefab = Instantiate(ghostPrefab);
            GhostPrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(1);

        //FlyEyeを二体生成
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(1);
        //FlyEyeを二体生成
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20,   - 4 * i);
        }
        yield return new WaitForSeconds(1);

        //test
        //Batを五体生成
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Batを五体生成
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Batを五体生成
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Batを五体生成
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(2);
        //FlyEyeを二体生成
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -3 * i);
        }
        yield return new WaitForSeconds(2);
        //FlyEyeを二体生成
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -3 * i);
        }
        yield return new WaitForSeconds(1);
        //Ghostを4体生成
        for (int i = 0; i < 4; i++)
        {
            GameObject GhostPrefab = Instantiate(ghostPrefab);
            GhostPrefab.transform.position = new Vector2(20,  2 * i);
        }
        yield return new WaitForSeconds(1);

                //flyeyeを並列で3体生成
        for (int i = 0; i < 3; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 3,0);
        }
        */
    }
}