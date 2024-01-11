using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Archer : Enemy
{
    [Header("Archer Specifics")]
    public static int arrowDirection;
    public Vector2 jumpVelocity;
    public float jumpCooldown;
    [HideInInspector] public float lastTimeJumped;
    public float safeDistance; //if player goes inside the safeDistance, it will trigger the archer's jump in battle state (if archer can jump)

    [Header("Additional Collision Info")]
    [SerializeField] private Transform groundBehindCheck;
    [SerializeField] private Vector2 groundBehindCheckSize;


    #region States
    public ArcherIdleState idleState { get; private set; }
    public ArcherMoveState moveState { get; private set; }
    public ArcherBattleState battleState { get; private set; }
    public ArcherAttackState attackState { get; private set; }
    public ArcherDeadState deadState { get; private set; }
    public ArcherJumpState jumpState { get; private set; }
    #endregion


    protected override void Awake()
    {
        base.Awake();
        idleState = new ArcherIdleState(this, stateMachine, "Idle", this);
        moveState = new ArcherMoveState(this, stateMachine, "Move", this);
        battleState = new ArcherBattleState(this, stateMachine, "Idle", this);
        attackState = new ArcherAttackState(this, stateMachine, "Attack", this);
        deadState = new ArcherDeadState(this, stateMachine, "Idle", this);
        jumpState = new ArcherJumpState(this, stateMachine, "Jump", this);

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initalize(idleState);

    }

    protected override void Update()
    {
        base.Update();
        arrowDirection = facingDir;
        stateMachine.currentState.Update();
    }

    public override void Die()
    {
        base.Die();
        stateMachine.changeState(deadState);
    }

    public bool GroundBehind() => Physics2D.BoxCast(groundBehindCheck.position, groundBehindCheckSize, 0, Vector2.zero, 0, whatIsGround);
    public bool WallBehind() => Physics2D.Raycast(wallCheck.position, Vector2.right * -facingDir, wallCheckDistance + 2, whatIsGround);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireCube(groundBehindCheck.position, groundBehindCheckSize);
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + (wallCheckDistance + 2) * -facingDir, wallCheck.position.y));
    }
}
