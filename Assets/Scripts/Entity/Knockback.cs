using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Tooltip("The force that one entity knocks another entity back by")]
    public float thrust;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
        Vector2 forceDirection = enemy.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        enemy.velocity = force;
        yield return new WaitForSeconds(.3f);
        enemy.velocity = Vector2.zero;
        enemy.GetComponent<Enemy>().currentState = EnemyState.idle;

    }
}
