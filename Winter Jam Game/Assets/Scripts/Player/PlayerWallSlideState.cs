using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }
        
        if (yInput >= 0)
        {
            //player falls slower while on a wall than when player is in air
            rb.velocity = new Vector2(0, rb.velocity.y * 0.7f);
        }

        if (xInput != 0 && xInput != player.facingDir)
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (!player.isWallDetected())
        {
            stateMachine.ChangeState(player.idleState);

        }


        if (player.isGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

 
}
