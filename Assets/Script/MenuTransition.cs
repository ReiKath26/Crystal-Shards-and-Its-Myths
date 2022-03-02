using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{

    public GameObject Panel;
    public GameObject close;

    public void FadetoMenu()
    {
        if(Panel!=null && close!=null)
        {
            Panel.SetActive(true);
            close.SetActive(false);
        }
    }
}
