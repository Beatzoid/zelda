using UnityEngine;

public class Log : Enemy
{
    [Tooltip("The target to chase")]
    public Transform target;

    [Tooltip("The radius at which to start chasing the target")]
    public float chaseRadius;

    [Tooltip("The radius at which to start attacking the target")]
    public float attackRadius;

    [Tooltip("The place to return to when out of range of the target")]
    public Transform homePosition;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        currentState = EnemyState.idle;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeState(EnemyState.walk);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
