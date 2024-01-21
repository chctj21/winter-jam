using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Transform spikesCheck;
    public Vector2 spikesHitbox;
    public LayerMask whatIsPlayer;
    public float spikesTimer;
    public float spikesCooldown;

    private void Update()
    {
       if (PlayerHitSpikes() && spikesTimer <= 0)
        {
            PlayerManager.instance.player.GetComponent<PlayerStats>().TakeDamage(10);
            PlayerManager.instance.player.Damage();
            spikesTimer = spikesCooldown; 

        }
        else
        {
            spikesTimer -= Time.deltaTime;
        }

    }
    private bool PlayerHitSpikes() => Physics2D.BoxCast(spikesCheck.position, spikesHitbox, 0, Vector2.zero, 0, whatIsPlayer);

    //problem is box collider needs to be tall enough to collide with player's capusle collider, so the player looks like she is floating over the spikes
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("spikes");
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
        }    
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(spikesCheck.position, spikesHitbox);
    }


}
