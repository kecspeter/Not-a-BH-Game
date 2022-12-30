using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    [Header("Component References")]
    public Animator PlayerAnimator;
    public Vector2 Velocity;

    //Animation String IDs
    //private int playerAttackAnimation_ID;
    private int PlayerMovementVelocityX_ID;
    private int PlayerMovementVelocityY_ID;
    private int PlayerMovementSpeed_ID;

    public void SetupBehaviour()
    {
        SetupAnimationIDs();
    }

    void SetupAnimationIDs()
    {
        //playerAttackAnimation_ID = Animator.StringToHash("Attack");
        PlayerMovementVelocityX_ID = Animator.StringToHash("VelocityX");
        PlayerMovementVelocityY_ID = Animator.StringToHash("VelocityY");
        PlayerMovementSpeed_ID = Animator.StringToHash("Speed");
    }

    public void UpdateMovementAnimation(Rigidbody2D rigidbody2d)
    {
        Velocity = rigidbody2d.velocity.normalized;

        PlayerAnimator.SetFloat(PlayerMovementVelocityX_ID, Velocity.x);
        PlayerAnimator.SetFloat(PlayerMovementVelocityY_ID, Velocity.y);

        PlayerAnimator.SetFloat(PlayerMovementSpeed_ID, rigidbody2d.velocity.sqrMagnitude);

        //Changing the animation speed based on the given velocity 
        //TODO: Currently hardcoded with speed ... will be refactored into a separated class
        if( Velocity.sqrMagnitude > 0)
        {
            PlayerAnimator.speed = rigidbody2d.velocity.sqrMagnitude / 25.0f;
        }
        else
        {
            PlayerAnimator.speed = 1;
        }

    }

    public void PlayAttackAnimation()
    {
        //PlayerAnimator.SetTrigger(PlayerAttackAnimation_ID);
    }
    
    

}
