using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Smash()
    {
        anim.SetBool("smash", true);
    }

    public void onPotDestroy()
    {
        this.gameObject.SetActive(false);
    }
}
