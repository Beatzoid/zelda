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

    [Tooltip("The health of the enemy")]
    public int health;

    [Tooltip("The name of the enemy")]
    public string enemyName;

    [Tooltip("The base attack damage")]
    public int baseAttack;

    [Tooltip("The move speed of the enemy")]
    public float moveSpeed;
}
