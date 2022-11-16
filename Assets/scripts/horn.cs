using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class horn : MonoBehaviour
{
    public bool isOn = false;
    public GameObject obj;
    new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (isOn == false)
            {
                audio = obj.GetComponent<AudioSource>();
                audio.Play();
               // isOn = true;
            }
        }
    }
}
