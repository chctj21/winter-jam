using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    public GameObject gameOverScreen;

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    //damages all enemies in the hitbox of the player (hitbox is determined by player.attackCheck.position and player.attackCheckRadius)
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage();
                hit.GetComponent<CharacterStats>().TakeDamage(player.stats.damage.GetValue());
            }
        }
    }

    public void ActivateGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}