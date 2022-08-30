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
    }
    void Update(){
        if(currentState == AnimStates.Walk){
            if(facingDir == FacingDir.Front){
                if(Input.GetKeyUp(KeyCode.S)){
                    currentState = AnimStates.Idle;
                    if (lastState != currentState){
                        anim.Play("F_IDLE");
                        lastState = currentState;
                    }
                }
            } else {
                if(Input.GetKeyUp(KeyCode.W)){
                    currentState = AnimStates.Idle;
                    if (lastState != currentState){
                        anim.Play("B_IDLE");
                        lastState = currentState;
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.W)){
            currentState = AnimStates.Walk;
            facingDir = FacingDir.Back;
            if (lastState != currentState){
                anim.Play("B_WALK");
                lastState = currentState;
            }
        }
        
        if (Input.GetKey(KeyCode.S)){
            currentState = AnimStates.Walk;
            facingDir = FacingDir.Front;
            if (lastState != currentState){
                anim.Play("F_WALK");
                lastState = currentState;
            }
        }
        
    }

}
