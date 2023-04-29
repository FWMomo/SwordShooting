using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenelator : MonoBehaviour
{
    //ƒvƒŒƒnƒuŠi”[
    public GameObject batPrefab;
    public GameObject ghostPrefab;
    public GameObject flyEyePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Genelator");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Genelator()
    {
        Debug.Log(11111);
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            Debug.Log(2);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 4);
        }
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 2; i++)
        {
            GameObject GhostPrefab = Instantiate(ghostPrefab);
            Debug.Log(2);
            GhostPrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(3);

        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            Debug.Log(2);
            flyEyePrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(3);
    }
}
