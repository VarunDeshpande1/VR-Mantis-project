using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
   
    private Rigidbody rb;
    public bool islft = false;
    public GameObject latch;
    public GameObject at45;
    //public GameObject cub2;
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
                rb.GetComponent<ConstantForce>().force = new Vector3(0, 110, 0);
                rb.GetComponent<ConstantForce>().enabled = true;
                islft = true;
                StartCoroutine(delayLift());
               
                latch.GetComponent<pullPush>().enabled = false;
                StartCoroutine(delay());
                //cub2.GetComponent<Rigidbody>().mass = 5;
            }
        }
        if(Input.GetKey(KeyCode.Y) || OVRInput.Get(OVRInput.RawButton.Y))
        {
            // rb.GetComponent<ConstantForce>().enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            StartCoroutine(lowerLift());
            // StartCoroutine(delayLonger());
           // cub2.GetComponent<Rigidbody>().mass = 1.5f;


            islft = false;
            latch.GetComponent<pullPush>().enabled = true;
            StartCoroutine(delay());
        }
    }

    IEnumerator lowerLift()
    {
        if(latch.GetComponent<pullPush>().enabled == true && latch.GetComponent<HingeJoint>())
        {
            rb.GetComponent<ConstantForce>().force = new Vector3(0, 93f, 0);
          // at45.GetComponent<ConstantForce>().force = new Vector3(0, -90f, 0);
            yield return new WaitForSeconds(3.12f);
           
            
            rb.GetComponent<ConstantForce>().enabled = false;
            rb.constraints = RigidbodyConstraints.None;
           // at45.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
        }
        else {
            rb.GetComponent<ConstantForce>().force = new Vector3(0, 105, 0);
            yield return new WaitForSeconds(4.5f);

            rb.GetComponent<ConstantForce>().enabled = false;
            rb.constraints = RigidbodyConstraints.None;
        }
        
       

    }
    IEnumerator delayLift()
    {
        
        yield return new WaitForSeconds(2);
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
    }

}

