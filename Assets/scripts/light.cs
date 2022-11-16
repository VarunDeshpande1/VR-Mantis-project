using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public bool isOn = false;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L)||OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            if(isOn==false)
            {
                obj.SetActive(true);
                isOn = true;
            }
            else
            {
                obj.SetActive(false);
                isOn = false;
            }
        }
    }
}
