using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    //エナジーチャージ量
    private float chargeRate = 0.267f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnergyCharger(int energy)
    {
        Debug.Log("yes");
        if(this.transform.position.x + chargeRate * energy >= 4)
        {
            this.transform.position = new Vector2(4, this.transform.position.y);
        }
        else
        {
            this.transform.position = new Vector2(this.transform.position.x + chargeRate * energy, this.transform.position.y);
        }
    }
}
