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

    private Animator anim;
    private Rigidbody2D logRigidbody;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        currentState = EnemyState.idle;
        anim = GetComponent<Animator>();
        logRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= chaseRadius && distance > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                logRigidbody.MovePosition(temp);

                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (distance > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    private void changeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
