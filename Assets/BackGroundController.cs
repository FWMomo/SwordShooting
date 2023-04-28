using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    //road�̑��x
    private float roadScrollSpeed = -3;
    //mountain�̑��x
    private float mountainScrollSpeed;
    //cloud�̑��x
    private float cloudScrollSpeed;

    //�J�n�E�I���n�_
    private float deadLine = -40;
    private float startLine = 40;

    // Start is called before the first frame update
    void Start()
    {
        mountainScrollSpeed = roadScrollSpeed * 1 / 3;
        cloudScrollSpeed = roadScrollSpeed * 2 / 3;
    }

    // Update is called once per frame
    void Update()
    {
        //�X�N���[�����x
        if(this.gameObject.tag == "RoadTag")
        {
            this.transform.Translate(roadScrollSpeed * Time.deltaTime, 0, 0);
        }
        else if(this.gameObject.tag == "MountainTag")
        {
            this.transform.Translate(mountainScrollSpeed * Time.deltaTime, 0, 0);
        }
        else if(this.gameObject.tag == "CloudTag")
        {
            this.transform.Translate(cloudScrollSpeed * Time.deltaTime, 0, 0);
        }

        //��ʒ[�ňړ�
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}
