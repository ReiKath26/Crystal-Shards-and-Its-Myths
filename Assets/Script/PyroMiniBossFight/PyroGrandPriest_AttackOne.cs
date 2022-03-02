using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroGrandPriest_AttackOne : StateMachineBehaviour
{
    private GrandProjectile Grandz;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Grandz = GrandProjectile.Grands.GetComponent<GrandProjectile>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GrandProjectile.Grands.Idle();
    }


}
