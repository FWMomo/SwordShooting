using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private float time;
    //アイテム消滅時間
    private float destroyTime = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= destroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
