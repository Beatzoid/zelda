using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Tooltip("The force that one entity knocks another entity back by")]
    public float thrust;
    [Tooltip("How long to knock the entity for")]
    public float knockTime = .3f;
    [Tooltip("The amount of damage to do when the entity is knocked back")]
    public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Pot>().Smash();
        }

        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (other.CompareTag("Enemy") && other.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }

                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime);
                    }
                }
            }
        }
    }
}
