using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenelator : MonoBehaviour
{
    //ƒvƒŒƒnƒuŠi”[
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
        //Bat‚ğŒÜ‘Ì¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 4);
        }
        yield return new WaitForSeconds(4);

        //Bat‚ğŒÜ‘Ì¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(4);

        //Bat‚ğŒÜ‘Ì¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, -4);
        }
        yield return new WaitForSeconds(4);

        //FlyEye‚ğ“ñ‘Ì¶¬
        for (int i = 0; i < 3; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 2, 2 - 4 * i);
        }
        yield return new WaitForSeconds(3);

        //Ghost2‚ğ3‘Ì¶¬
        for (int i = 0; i < 3; i++)
        {
            GameObject GhostPrefab2 = Instantiate(ghostPrefab2);
            GhostPrefab2.transform.position = new Vector2(20 + i * 3,0);
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(3);

        //skelton‚ğˆê‘Ì¶¬
        GameObject SkeltonPrefab = Instantiate(skeltonPrefab);
        SkeltonPrefab.transform.position = new Vector2(23,-2);
        yield return new WaitForSeconds(3);
        /*
         * //Ghost‚ğ“ñ‘Ì¶¬
        for (int i = 0; i < 2; i++)
        {
            GameObject GhostPrefab = Instantiate(ghostPrefab);
            GhostPrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(1);

        //FlyEye‚ğ“ñ‘Ì¶¬
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -4 - 4 * i);
        }
        yield return new WaitForSeconds(1);
        //FlyEye‚ğ“ñ‘Ì¶¬
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20,   - 4 * i);
        }
        yield return new WaitForSeconds(1);

        //test
        //Bat‚ğŒÜ‘Ì¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Bat‚ğŒÜ‘Ì¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Bat‚ğŒÜ‘Ì¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(1);
        //Bat‚ğŒÜ‘Ì¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject BatPrefab = Instantiate(batPrefab);
            BatPrefab.transform.position = new Vector2(20 + i * 2, 0);
        }
        yield return new WaitForSeconds(2);
        //FlyEye‚ğ“ñ‘Ì¶¬
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -3 * i);
        }
        yield return new WaitForSeconds(2);
        //FlyEye‚ğ“ñ‘Ì¶¬
        for (int i = 0; i < 2; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20, -3 * i);
        }
        yield return new WaitForSeconds(1);
        //Ghost‚ğ4‘Ì¶¬
        for (int i = 0; i < 4; i++)
        {
            GameObject GhostPrefab = Instantiate(ghostPrefab);
            GhostPrefab.transform.position = new Vector2(20,  2 * i);
        }
        yield return new WaitForSeconds(1);

                //flyeye‚ğ•À—ñ‚Å3‘Ì¶¬
        for (int i = 0; i < 3; i++)
        {
            GameObject FlyEyePrefab = Instantiate(flyEyePrefab);
            FlyEyePrefab.transform.position = new Vector2(20 + i * 3,0);
        }
        */
    }
}