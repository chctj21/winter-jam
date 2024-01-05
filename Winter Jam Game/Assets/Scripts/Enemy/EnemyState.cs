using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected bool triggerCalled;
    protected float stateTimer;
    private string animBoolName;
    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string animBoolName) 
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        triggerCalled = false;
        enemy.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit() 
    {
        enemy.anim.SetBool(animBoolName, false);
    }
}
