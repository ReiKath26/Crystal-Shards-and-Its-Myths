using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject pan;

    void Start()
    {
        pan.SetActive(false);
    }

    void OnMouseOver()
    {

        if(pan!=null)
        {
            pan.SetActive(true);
        }
    }

    void OnMouseExit()
    {

        if(pan!=null)
        {
            pan.SetActive(false);
        }
    }
}
