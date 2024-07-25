using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] AudioSource WalkSound;
    [SerializeField] AudioSource CatchSound;
    [SerializeField] AudioSource SuspenseSound;

    private Animator animator;

    // Animation States
    private string idleAnimation01 = "Idle01";
    private string idleAnimation02 = "Idle02";
    private string idleAnimation03 = "Idle03";
    private string walkAnimation01 = "Walk01";
    private string chaseAnimation01 = "Chase01";

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(true);
    }

    public void IdleAnimation01()
    {
        gameObject.SetActive(true);
        animator.Play(idleAnimation01);
    }

    public void IdleAnimation02()
    {
        gameObject.SetActive(true);
        animator.Play(idleAnimation02);
    }

    public void IdleAnimation03()
    {
        gameObject.SetActive(true);
        animator.Play(idleAnimation03);
        SuspenseSound.Play();
    }

    public void ChaseAnimation01()
    {
        animator.SetTrigger(chaseAnimation01);
        CatchSound.Play();
    }

    public void WalkAnimation01()
    {
        animator.SetTrigger(walkAnimation01);
        WalkSound.Play();
    }

    public void Deactivate() 
    {
        gameObject.SetActive(false);
    }
}
