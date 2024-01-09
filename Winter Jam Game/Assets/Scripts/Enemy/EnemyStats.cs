using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Die()
    {
        base.Die();
        enemy.Die();
    }

}
