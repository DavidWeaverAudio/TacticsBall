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
    FrontLeft,
    BackLeft,
    FrontRight,
    BackRight
}
public class CharacterController : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    public FacingDir facingDir;
    public AnimStates lastState;
    public AnimStates currentState;
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        anim.Play("F_IDLE");
    }
    public void StartWalking(FacingDir facing)
    {
        if (anim == null)
        {
            return;
        }
        FlipSpriteX(facing);
        facingDir = facing;

        if (facingDir == FacingDir.FrontLeft || facingDir == FacingDir.FrontRight)
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
    void FlipSpriteX(FacingDir facing)
    {
        if (facing == FacingDir.FrontRight || facing == FacingDir.BackRight)
        {
            sprite.flipX = true;
        } else
        {
            sprite.flipX = false;
        }
    }
    public void StopWalking(FacingDir facing)
    {
        if (anim == null)
        {
            return;
        }
        facingDir = facing;
        FlipSpriteX(facing);
        
        if (facing == FacingDir.FrontLeft || facing == FacingDir.FrontRight)
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
