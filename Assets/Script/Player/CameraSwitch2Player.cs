using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch2Player : MonoBehaviour
{

    private Animator anim;
    private bool AlexaCam;
    private bool ClaudeCam;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AlexaCam = false;
        ClaudeCam = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
                anim.Play("AlexaCam");
                ClaudeCam = false;
                AlexaCam = true;
        }

         if(Input.GetKey(KeyCode.Alpha2))
        {
                anim.Play("ClaudeCam");
                AlexaCam = false;
                ClaudeCam = true;
        }

    }
}
