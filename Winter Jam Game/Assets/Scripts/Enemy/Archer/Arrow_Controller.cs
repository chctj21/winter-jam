using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Controller : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string targetLayerName = "Player";
    public int arrowDirection = 1;
    [SerializeField] private float xSpeed;
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            collision.GetComponent<CharacterStats>().TakeDamage(damage);
            StuckInto(collision);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            StuckInto(collision);
        }
    }

    private void StuckInto(Collider2D collision)
    {
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        rb.velocity = new Vector2(arrowDirection * xSpeed, rb.velocity.y);
    }

    public void FlipArrow()
    {

        arrowDirection = arrowDirection * -1;
        transform.Rotate(0, 180, 0);
        targetLayerName = "Enemy";
    }
}
