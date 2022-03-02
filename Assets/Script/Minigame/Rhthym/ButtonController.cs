using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultKey;
    public Sprite pressedKey;

    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            theSR.sprite = pressedKey;
        }

        if(Input.GetKeyUp(key))
        {
            theSR.sprite = defaultKey;
        }
    }
}
