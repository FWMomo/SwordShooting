using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenelator : MonoBehaviour
{
    //�v���n�u�i�[
    public GameObject knight;
    public GameObject batPrefab;
    public GameObject ghostPrefab;
    public GameObject flyEyePrefab;
    public GameObject ghost2Prefab;
    public GameObject skeltonPrefab;
    public GameObject flyEye2Prefab;
    public GameObject slimeBossPrefab;

    int random = 0;

    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.Find("Knight");
        StartCoroutine(Genelate());
    }

    // Update is called once per frame
    void Update()
    {
        if (!knight.GetComponent<KnightController>().isGameOver)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Genelate()
    {
        //Bat���ܑ̐���
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 4);
        }
        yield return new WaitForSeconds(4);

        //Bat���ܑ̐���
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(4);

        //Bat���ܑ̐���
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, -4);
        }
        yield return new WaitForSeconds(4);

        //FlyEye���̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 2, 2 - 4 * i);
        }
        yield return new WaitForSeconds(3);

        //Ghost2��3�̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject Ghost2Prefab = Instantiate(ghost2Prefab);
            Ghost2Prefab.transform.position = new Vector2(20, 0);
            Ghost2Prefab.GetComponent<GhostController2>().Position(20, 4);
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(1.5f);

        //Ghost2��3�̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject Ghost2Prefab = Instantiate(ghost2Prefab);
            Ghost2Prefab.transform.position = new Vector2(20, 0);
            Ghost2Prefab.GetComponent<GhostController2>().Position(20, 0);
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(1.5f);

        //Ghost2��3�̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject Ghost2Prefab = Instantiate(ghost2Prefab);
            Ghost2Prefab.transform.position = new Vector2(20, 0);
            Ghost2Prefab.GetComponent<GhostController2>().Position(20, -4);
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(3);

        //skelton����̐���
        GameObject SkeltonPrefab = Instantiate(skeltonPrefab);
        SkeltonPrefab.transform.position = new Vector2(23,-2);
        yield return new WaitForSeconds(2);

        //Bat��3�̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 5);
        }
        yield return new WaitForSeconds(2);

        //FlyEye2��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEye2Prefab = Instantiate(flyEye2Prefab);
            FlyEye2Prefab.transform.position = new Vector2(20 + i * 2, 8);
        }
        yield return new WaitForSeconds(4);

        //Bat��3�̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(3);

        //FlyEye��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 2,i);
        }
        yield return new WaitForSeconds(3);

        //FlyEye��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 2, -4 + i);
        }
        yield return new WaitForSeconds(3);

        //Bat��10�̐���
        for (int i = 0; i < 10; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2,5 + 0.5f * i);
        }

        //Bat��10�̐���
        for (int i = 0; i < 10; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2,-5 -0.5f * i);
        }
        yield return new WaitForSeconds(2);

        //Ghost2��3�̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject Ghost2Prefab = Instantiate(ghost2Prefab);
            Ghost2Prefab.transform.position = new Vector2(20, 0);
            Ghost2Prefab.GetComponent<GhostController2>().Position(20, 0);
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(1);

        random = Random.Range(2, 8);
        //FlyEye2��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEye2Prefab = Instantiate(flyEye2Prefab);
            FlyEye2Prefab.transform.position = new Vector2(20 + i * 4, random);
        }
        yield return new WaitForSeconds(1.3f);

        random = Random.Range(3, 8);
        //FlyEye2��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEye2Prefab = Instantiate(flyEye2Prefab);
            FlyEye2Prefab.transform.position = new Vector2(20 + i * 4, random);
        }
        yield return new WaitForSeconds(1.3f);

        random = Random.Range(3, 8);
        //FlyEye2��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEye2Prefab = Instantiate(flyEye2Prefab);
            FlyEye2Prefab.transform.position = new Vector2(20 + i * 4, random);
        }
        yield return new WaitForSeconds(1.3f);

        //Ghost2�������_���ȏꏊ��5�̐���
        for (int i = 0; i < 5; i++)
        {
            random = Random.Range(-8, 8);
            GameObject Ghost2Prefab = Instantiate(ghost2Prefab);
            Ghost2Prefab.transform.position = new Vector2(20, 0);
            Ghost2Prefab.GetComponent<GhostController2>().Position(20, random);
            yield return new WaitForSeconds(0.5f);
        }

        //Bat��10�̐���
        for (int i = 0; i < 15; i++)
        {
            random = Random.Range(-8, 8);
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 1, random);
        }
        yield return new WaitForSeconds(4);

        random = Random.Range(2, 8);

        //FlyEye��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEye2Prefab = Instantiate(flyEye2Prefab);
            FlyEye2Prefab.transform.position = new Vector2(20 + i * 4, random);
        }
        yield return new WaitForSeconds(1.3f);

        random = Random.Range(2, 8);
        //FlyEye��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEye2Prefab = Instantiate(flyEye2Prefab);
            FlyEye2Prefab.transform.position = new Vector2(20 + i * 4, random);
        }
        yield return new WaitForSeconds(1.3f);

        random = Random.Range(2, 8);
        //FlyEye��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject FlyEye2Prefab = Instantiate(flyEye2Prefab);
            FlyEye2Prefab.transform.position = new Vector2(20 + i * 4, random);
        }
        yield return new WaitForSeconds(1);

        //�{�X�G
        yield return new WaitForSeconds(5);

        GameObject SlimeBossPrefab = Instantiate(slimeBossPrefab);
        SlimeBossPrefab.transform.position = new Vector2(28, 2);


        /*
         * //Ghost���̐���
        for (int i = 0; i < 2; i++)
        {
            GameObject GhostPrefab = Instantiate(ghostPrefab);
            GhostPrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(1);

        //FlyEye���̐���
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(1);
        //FlyEye���̐���
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20,   - 4 * i);
        }
        yield return new WaitForSeconds(1);

        //test
        //Bat���ܑ̐���
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Bat���ܑ̐���
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Bat���ܑ̐���
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Bat���ܑ̐���
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(2);
        //FlyEye���̐���
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -3 * i);
        }
        yield return new WaitForSeconds(2);
        //FlyEye���̐���
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -3 * i);
        }
        yield return new WaitForSeconds(1);
        //Ghost��4�̐���
        for (int i = 0; i < 4; i++)
        {
            GameObject GhostPrefab = Instantiate(ghostPrefab);
            GhostPrefab.transform.position = new Vector2(20,  2 * i);
        }
        yield return new WaitForSeconds(1);

                //flyeye������3�̐���
        for (int i = 0; i < 3; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 3,0);
        }
        */
    }
}