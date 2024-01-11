using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ArcherAnimationTriggers : Enemy_AnimationTriggers
{
    [SerializeField] private GameObject arrow;
    private void ShootArrow()
    {
        Instantiate(arrow, enemy.attackCheck.position, Quaternion.identity);
    }
}
