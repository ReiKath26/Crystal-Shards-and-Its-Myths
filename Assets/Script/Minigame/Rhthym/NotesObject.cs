using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    public GameObject NormalEffect, GoodEffect, PerfectEffect, MissEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                // GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > 0.75f)
                {
                    GameManager.instance.NormalHit();
                    Instantiate(NormalEffect, transform.position, NormalEffect.transform.rotation);
                }

                else if(Mathf.Abs(transform.position.y) > 0.5f)
                {

                    GameManager.instance.GoodHit();
                    Instantiate(GoodEffect, transform.position, NormalEffect.transform.rotation);
                }

                else
                {
    
                    GameManager.instance.PerfectHit();
                    Instantiate(PerfectEffect, transform.position, NormalEffect.transform.rotation);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if(gameObject.active)
        {
             if(other.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();
                Instantiate(MissEffect, transform.position, MissEffect.transform.rotation);
             }
        }
    }
}
