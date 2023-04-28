using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    
    private float speed = -10;
    private float deadLine = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ����x
        transform.Translate(this.speed * Time.deltaTime, 0,0);
        //��ʒ[�ɍs���������
        if(this.transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }
}
