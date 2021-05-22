using System.Collections;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The speed of the player")]
    public float speed;

    [Tooltip("Current player state")]
    public PlayerState currentState;

    private Rigidbody2D playerRigidbody;
    private Vector3 change;
    private Animator anim;

    void Start()
    {
        Application.targetFrameRate = 60;
        currentState = PlayerState.walk;
        playerRigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        anim.SetFloat("moveX", 0);
        anim.SetFloat("moveY", -1);
    }

    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Attack")
            && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            updateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void updateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        playerRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCoroutine(knockTime));
    }

    private IEnumerator KnockCoroutine(float knockTime)
    {
        if (playerRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            playerRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
