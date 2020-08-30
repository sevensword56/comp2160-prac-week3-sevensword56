using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float turboSpeed = 1.0f;
    public float turboDelay = 2.0f;
    public float turboTimeOut = 1.0f;

    private float timer = 1.0f;
    private bool turboActive = true;
    private bool timerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 1.0f;
        float rotation = 1.0f;
        
        timer -= Time.deltaTime;

        if(Input.GetButton("Turbo") == true && turboActive == true)
        {
            movement = (Input.GetAxis("Vertical") * turboSpeed) * Time.deltaTime;
            if(timerActive == false)
            {   
                timer = turboTimeOut;
                timerActive = true;
            }
        }
        else
        {
            movement = (Input.GetAxis("Vertical") * movementSpeed) * Time.deltaTime;
        }
        rotation = (Input.GetAxis("Horizontal") * rotationSpeed) * Time.deltaTime;
    
        if(timer <= 0 && turboActive == true)
        {
            turboActive = false;
            timer = turboDelay;
        }
        else if (timer <= 0 && turboActive == false)
        {
            turboActive = true;
            timerActive = false;
        }

        transform.Translate(0,0,movement);
        transform.Rotate(0,rotation,0);
    }
}
