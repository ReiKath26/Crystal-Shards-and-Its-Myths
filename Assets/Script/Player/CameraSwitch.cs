using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private Animator anim;
    private bool AlexaCam;
    private bool ClaudeCam;
    private bool JeremyCam;
    public bool isBoss;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AlexaCam = false;
        ClaudeCam = false;
        JeremyCam = true;
        isBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1) && !isBoss)
        {
            if(JeremyCam)
            {
                anim.Play("AlexaCam");
                JeremyCam = false;
                AlexaCam = true;
            }

            else if(ClaudeCam)
            {
                anim.Play("AlexaCam");
                ClaudeCam = false;
                AlexaCam = true;
            }
        }

         if(Input.GetKey(KeyCode.Alpha2) && !isBoss)
        {
            if(JeremyCam)
            {
                anim.Play("ClaudeCam");
                JeremyCam = false;
                ClaudeCam = true;
            }

            else if(AlexaCam)
            {
                anim.Play("ClaudeCam");
                AlexaCam = false;
                ClaudeCam = true;
            }
        }


         if(Input.GetKey(KeyCode.Alpha3) && !isBoss)
        {
            if(ClaudeCam)
            {
                anim.Play("JeremyCam");
                JeremyCam = true;
                ClaudeCam = false;
            }

            else if(AlexaCam)
            {
                anim.Play("JeremyCam");
                AlexaCam = false;
                JeremyCam = true;
            }
        }

        if(Input.GetKey(KeyCode.C))
        {
            anim.Play("FixCam");
            isBoss = true;
            AlexaCam = false;
            ClaudeCam = false;
            JeremyCam = true;
        }
    }
}
