using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherJumpState : EnemyState
{
    private Enemy_Archer enemy;
    public ArcherJumpState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animBoolName, Enemy_Archer _enemy) : base(_enemyBase, _stateMachine, animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(enemy.jumpVelocity.x * -enemy.facingDir, enemy.jumpVelocity.y);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.lastTimeJumped = Time.time;
    }

    public override void Update()
    {
        base.Update();
        enemy.anim.SetFloat("yVelocity", rb.velocity.y);
        if (rb.velocity.y<0 && enemy.isGroundDetected())
        {
            stateMachine.changeState(enemy.battleState);
        }
    }
}
