using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float speed, turnSpeed;
    private Rigidbody rb;
    public bool isEon = false;
    public bool isCon = false;
    public bool isMon = false;

    // Start is called before the first frame update
    void mover()
    {
        if (Input.GetKey(KeyCode.W) || OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) == Vector2.up || OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            rb.AddRelativeForce(Vector3.forward * speed * 10);
        }
        else if (Input.GetKey(KeyCode.S) || OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) == Vector2.down || OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            rb.AddRelativeForce(Vector3.back * speed * 10);
        }
    }

    void lftrt()
    {
        if (Input.GetKey(KeyCode.A) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.left || OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            rb.AddTorque(Vector3.down * turnSpeed * 11.5f);
        }

        else if (Input.GetKey(KeyCode.D) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.right || OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            rb.AddTorque(Vector3.up * turnSpeed * 11.5f);
        }

    }

    void centralMovement()
    {
        if (Input.GetKey(KeyCode.A) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.left || OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            rb.AddRelativeTorque(Vector3.down * turnSpeed * 18);
        }
        if (Input.GetKey(KeyCode.D) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.right || OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            rb.AddRelativeTorque(Vector3.up * turnSpeed * 18);
        }
    }

    void sideMoment()
    {
      
                if (Input.GetKey(KeyCode.A) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.left || OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
                {
                    rb.AddRelativeForce(Vector3.left * speed * 10);
                }
                if (Input.GetKey(KeyCode.D) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.right || OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
                {
                    rb.AddRelativeForce(Vector3.right * speed * 10);
                }
            
            
      
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.M))
        {
            if (isMon == false)
            { isMon = true; }

            else
            { isMon = false; }
        }

        if (isMon == true && isCon == false)
        {
            sideMoment();
        }


        if (Input.GetKey(KeyCode.C))
        {
            if (isCon == false)
            { isCon = true; }

            else
            { isCon = false; }
        }

        if (isCon == true && isMon == false)
        {
            centralMovement();
        }
       
        mover();
        if (isCon == false && isMon ==false)
        {
            lftrt();
        }
    

           


        if (Input.GetKey(KeyCode.E))
        {
            rb.angularDrag = 0.16f;
        }

       

        if (Input.GetKey(KeyCode.G))                                                                        //Emergency stop
        {
            if (isEon == false)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                isEon = true;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                isEon = false;
            }
        }
    }
}
