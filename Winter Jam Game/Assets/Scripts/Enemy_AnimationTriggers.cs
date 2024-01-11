using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimationTriggers : MonoBehaviour
{
    protected Enemy enemy => GetComponentInParent<Enemy>();

    private void AnimationTriggers()
    {
        enemy.AnimationFinishTrigger();
    }

    private void AttackTriggers()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Player>().Damage();
                hit.GetComponent<PlayerStats>().TakeDamage(enemy.stats.damage.GetValue());
            }
        }
    }

    private void OpenCounterWindow()
    {
        enemy.OpenCounterAttackWindow();
    }
    private void CloseCounterWindow() => enemy.CloseCounterAttackWindow();
}
