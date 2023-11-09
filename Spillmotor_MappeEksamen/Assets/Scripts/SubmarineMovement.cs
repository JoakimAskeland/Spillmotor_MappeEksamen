using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    public Transform sub;

    float Speed = 0;
    float MaxSpeed = 10;
    float Acceleration = 10;
    float Deceleration = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W)) && (Speed < MaxSpeed))
        {
            Speed = Speed - Acceleration * Time.deltaTime;
        }
        else if ((Input.GetKeyDown(KeyCode.S)) && (Speed > -MaxSpeed))
        {
            Speed = Speed + Acceleration * Time.deltaTime;
        }
        else
        {
            if (Speed > Deceleration * Time.deltaTime)
            {
                Speed = Speed - Deceleration * Time.deltaTime;
            }
            else if (Speed < -Deceleration * Time.deltaTime)
            {
                Speed = Speed + Deceleration * Time.deltaTime;
            }
            else
            {
                Speed = 0;
            }
        }

        //sub.transform.position.x = transform.position.x + Speed * Time.deltaTime;
        //sub.transform.position.x 
    }
}
