using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSwordController : MonoBehaviour
{
    //Á‹ŽˆÊ’u
    private float deadLine = 20;

    //‰ñ“]
    private float rotSpeed = -10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, this.rotSpeed);
        
        if (this.transform.position.x > deadLine)
        {
            Destroy(gameObject);
        }
    }
}
