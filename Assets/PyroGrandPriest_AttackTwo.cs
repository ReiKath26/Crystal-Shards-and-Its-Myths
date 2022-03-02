using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroGrandPriest_AttackTwo : StateMachineBehaviour
{
    //private GrandProjectile Grands;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Grands = GameObject.FindGameObjectWithTag("PriestBullet").GetComponent<GrandProjectile>();
        GrandProjectile.Grands.GetComponent<GrandProjectile>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        GrandProjectile.Grands.AttackStateOne();
    }

    
}
