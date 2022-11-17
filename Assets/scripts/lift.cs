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
                rb.GetComponent<ConstantForce>().force = new Vector3(0, 100, 0);
                rb.GetComponent<ConstantForce>().enabled = true;
                islft = true;
                StartCoroutine(delayLift());
               
                latch.GetComponent<pullPush>().enabled = false;
                StartCoroutine(delay());
            }
        }
        if(Input.GetKey(KeyCode.Y) || OVRInput.Get(OVRInput.RawButton.Y))
        {
           // rb.GetComponent<ConstantForce>().enabled = false;
            rb.freezeRotation = false;
           StartCoroutine(lowerLift());
            // StartCoroutine(delayLonger());

            

            islft = false;
            latch.GetComponent<pullPush>().enabled = true;
            StartCoroutine(delay());
        }
    }

    IEnumerator lowerLift()
    {
        if(latch.GetComponent<pullPush>().enabled == true && latch.GetComponent<HingeJoint>())
        {
            rb.GetComponent<ConstantForce>().force = new Vector3(0, 99.1f, 0);
            yield return new WaitForSeconds(2.930f);

            rb.GetComponent<ConstantForce>().enabled = false;
            rb.freezeRotation = false;
        }
        else {
            rb.GetComponent<ConstantForce>().force = new Vector3(0, 95, 0);
            yield return new WaitForSeconds(4.5f);

            rb.GetComponent<ConstantForce>().enabled = false;
            rb.freezeRotation = false;
        }
        
       

    }
    IEnumerator delayLift()
    {
        
        yield return new WaitForSeconds(2);
        rb.freezeRotation = true;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
    }

}

