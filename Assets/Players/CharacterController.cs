using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimStates {
    Idle,
    Walk,
    Run,
    Jump,
    Fall,
    Land,
    Attack,
    Hit,
    Die
}
public enum FacingDir {
    Front,
    Back
}
public class CharacterController : MonoBehaviour
{
    Animator anim;
    public FacingDir facingDir;
    public AnimStates lastState;
    public AnimStates currentState;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("F_IDLE");
    }
    public void StartWalking(FacingDir facing)
    {
        if (anim == null)
        {
            return;
        }
        facingDir = facing;

        if (facingDir == FacingDir.Front)
        {
            anim.Play("F_WALK");
        }
        else
        {
            anim.Play("B_WALK");
        }
        currentState = AnimStates.Walk;
        lastState = currentState;
    }
    public void StopWalking(FacingDir facing)
    {
        facingDir = facing;
        if (anim == null)
        {
            return;
        }
        if (facing == FacingDir.Front)
        {
            anim.Play("F_IDLE");
        }
        else
        {
            anim.Play("B_IDLE");
        }
        currentState = AnimStates.Idle;
        lastState = currentState;
    }

}
