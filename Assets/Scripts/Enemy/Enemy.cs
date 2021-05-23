using System.Collections;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    [Tooltip("The current state of the enemy")]
    public EnemyState currentState;
    [Tooltip("The max health of the enemy")]
    public FloatValue maxHealth;

    [Tooltip("The health of the enemy")]
    public float health;

    [Tooltip("The name of the enemy")]
    public string enemyName;

    [Tooltip("The base attack damage")]
    public int baseAttack;

    [Tooltip("The move speed of the enemy")]
    public float moveSpeed;

    void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D rigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCoroutine(rigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCoroutine(Rigidbody2D rigidbody, float knockTime)
    {
        if (rigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rigidbody.velocity = Vector2.zero;
        }
    }
}
