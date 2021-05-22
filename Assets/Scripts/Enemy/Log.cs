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
    }

    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius) 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
