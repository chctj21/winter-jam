using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        //prevents the player from randomly sliding, think the cause of the sliding may be the physics of collisions
        if (player.isGroundDetected()) 
        {
            player.SetZeroVelocity();
        }
        base.Update();
        if (xInput == player.facingDir & player.isWallDetected())
        {
            return;
        }
        if (xInput != 0 && !player.isBusy)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
