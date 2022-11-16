using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullPush : MonoBehaviour
{
    public float distance;
    public LayerMask boxmask;
    bool adcomp = false;
    GameObject box;
    public GameObject plane;
    public bool planeStationary=true;
    public HingeJoint hjoint;
    public JointLimits lim;
    void Start()
    {
        plane.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Physics.Raycast(transform.position, Vector3.forward * transform.localScale.x,out RaycastHit hitinfo, distance, boxmask) && !adcomp && (Input.GetKey(KeyCode.E)|| OVRInput.Get(OVRInput.RawButton.A)))
        {
                                                                                                            //latch
            gameObject.AddComponent<HingeJoint>();
            hjoint = gameObject.GetComponent<HingeJoint>();
            lim = hjoint.limits;
            lim.min = -90;
            hjoint.limits = lim;
            hjoint.useLimits = true;
            gameObject.GetComponent<HingeJoint>().connectedBody = hitinfo.collider.attachedRigidbody;
            plane.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("hit");
            adcomp = true;
            planeStationary = false;
        }
        else { Debug.Log("miss"); }
        if (Input.GetKey(KeyCode.F)|| OVRInput.Get(OVRInput.RawButton.B))                                                                        //Unlatch
        {
            Destroy(gameObject.GetComponent<HingeJoint>());
            adcomp = false;
            planeStationary = true;
            plane.GetComponent<Rigidbody>().isKinematic = true;
        }

        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, (Vector3)transform.position + Vector3.forward * transform.localScale.x * distance);
    }

   
}
