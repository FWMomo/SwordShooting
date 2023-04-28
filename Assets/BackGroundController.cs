using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    //roadの速度
    private float roadScrollSpeed = -3;
    //mountainの速度
    private float mountainScrollSpeed;
    //cloudの速度
    private float cloudScrollSpeed;

    //開始・終了地点
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
        //スクロール速度
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

        //画面端で移動
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}
