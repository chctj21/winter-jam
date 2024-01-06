using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Enemy_Skeleton enemy;
    private Transform player;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
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
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance && CanAttack())
            {

                stateMachine.changeState(enemy.attackState);
            }
        }
        else if (stateTimer < 0 || Vector2.Distance(player.position, enemy.transform.position) > 15)
        {
            stateMachine.changeState(enemy.idleState);
        }
        if (Mathf.Abs(player.position.x - enemy.transform.position.x) < 0.25) // skeleton will not move and flip uncontrollably when too close to the player
                                                                              // 0.25 is an arbitary small number
        {
            moveDir = enemy.facingDir;
        }
        else if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if(player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
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
}
