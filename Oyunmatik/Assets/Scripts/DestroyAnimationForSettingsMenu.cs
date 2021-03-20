using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimationForSettingsMenu : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
    }
    /* This is only destroying animator gameobject when the animation finish.
     * This can be only use Main Menu between Settings Menu .
     * Otherwise it will get error if i use this in another scenes...
     */
}
