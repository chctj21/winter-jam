using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBattleState : EnemyState
{
    private Enemy_Archer enemy;
    private Transform player;
    private int moveDir;
    public ArcherBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animBoolName, Enemy_Archer _enemy) : base(_enemyBase, _stateMachine, animBoolName)
    {
        this.enemy = _enemy;
    }


    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;
            if (enemy.IsPlayerDetected().distance < enemy.safeDistance && CanJump())
            {
                stateMachine.changeState(enemy.jumpState);
            }
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance && CanAttack())
            {

                stateMachine.changeState(enemy.attackState);
            }
        }
        else if (stateTimer < 0 || Vector2.Distance(player.position, enemy.transform.position) > 15)
        {
            stateMachine.changeState(enemy.idleState);
        }
        BattleStateFlipControl();
    }

    private void BattleStateFlipControl()
    {
        if (player.position.x > enemy.transform.position.x && enemy.facingDir == -1)
        {
            enemy.Flip();
        }
        else if (player.position.x < enemy.transform.position.x && enemy.facingDir == 1)
        {
            enemy.Flip();
        }
    }

    private bool CanAttack()
    {
        if (Time.time > enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }

    private bool CanJump()
    {
        if (!enemy.GroundBehind() || enemy.WallBehind())
        {
            return false;
        }
        if (Time.time >= enemy.lastTimeJumped + enemy.jumpCooldown)
        {
            enemy.lastTimeJumped = Time.time;
            return true;
        }
        return false;
    }
}
