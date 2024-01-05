using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDashState : PlayerState
{
    public playerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();
        if (!player.isGroundDetected() && player.isWallDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }
        player.SetVelocity(player.dashSpeed * player.dashDir, rb.velocity.y); 
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
