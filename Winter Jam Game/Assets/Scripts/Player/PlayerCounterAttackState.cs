using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.counterAttackDuration;
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetZeroVelocity();


        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Arrow_Controller>() != null)
            {
                //arrows that enter the player's hitbox will be reflected towards the archer enemy
                hit.GetComponent<Arrow_Controller>().FlipArrow(); 
                SucessfulCounterAttack(); 
            }
            if (hit.GetComponent<Enemy>() != null)
            {
                //if player counters in a certain time window (window indicated by exclamation mark above enemy's head), enemy will be stunned
                //CanBeStunned() below is the method in the Enemy_Skeleton script, which inherits from CanBeStunned() in the Enemy script
                if (hit.GetComponent<Enemy>().CanBeStunned()) 
                {
                    SucessfulCounterAttack();
                }
            }
        }
        //player changes to an idle state if player spends enough time in counter attack state or at the end of a successful counter attack animation
        if (stateTimer < 0 || triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    private void SucessfulCounterAttack()
    {
        //10 is an aribitary big number
        stateTimer = 10; 
        player.anim.SetBool("SuccessfulCounterAttack", true);
    }
}
