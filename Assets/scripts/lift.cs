using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
   
    private Rigidbody rb;
    public bool islft = false;
    public GameObject latch;
    public GameObject at45;
   // HingeJoint hingejoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<ConstantForce>().enabled = false;
     //   rb.constraints = RigidbodyConstraints.FreezeRotationY;
     //   at45.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T)|| OVRInput.Get(OVRInput.RawButton.X))
        {
            if (islft == false)
            {
                rb.GetComponent<ConstantForce>().enabled = true;
                islft = true;
                StartCoroutine(delay());
               
                latch.GetComponent<pullPush>().enabled = false;
            }
        }
        if(Input.GetKey(KeyCode.Y) || OVRInput.Get(OVRInput.RawButton.Y))
        {
            rb.GetComponent<ConstantForce>().enabled = false;
            rb.freezeRotation = false;
            islft = false;
            latch.GetComponent<pullPush>().enabled = true;
        }
    }

    IEnumerator delay()
    {
        
        yield return new WaitForSeconds(3);
        rb.freezeRotation = true;


    }

     
    }

