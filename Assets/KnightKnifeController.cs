using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightKnifeController : MonoBehaviour
{
    //Á‹ŽˆÊ’u
    private float deadLine = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > deadLine)
        {
            Destroy(gameObject);
        }
    }
}
