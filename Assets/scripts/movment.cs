using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float speed, turnSpeed;
    private Rigidbody rb;
    public bool isEon = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)||OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)==Vector2.up || OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            rb.AddRelativeForce(Vector3.forward * speed * 10);
        }
       if (Input.GetKey(KeyCode.S) || OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) == Vector2.down || OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            rb.AddRelativeForce(-Vector3.forward * speed * 10);
        }

        if (Input.GetKey(KeyCode.A) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.left || OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            rb.AddRelativeTorque(-Vector3.up * turnSpeed * 10);
        }
        
         if (Input.GetKey(KeyCode.D) || OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) == Vector2.right ||  OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            rb.AddTorque(Vector3.up * turnSpeed * 10);
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
