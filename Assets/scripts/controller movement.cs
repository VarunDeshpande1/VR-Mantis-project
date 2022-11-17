using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllermovement : MonoBehaviour
{
    public Vector2 p1;
    public Vector2 p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        p1 = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        p2 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Debug.Log(p1);
        Debug.Log(p2);
    }
}
