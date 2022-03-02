using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAttackOne : StateMachineBehaviour
{
    [SerializeField] FinalBossScript boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = FinalBossScript.bossF.GetComponent<FinalBossScript>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.attackPlayerMelee();
    }

}
