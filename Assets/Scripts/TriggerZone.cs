using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [Header("On trigger Event")]
    [SerializeField] UnityEvent UnityEvent;
    [Tooltip("Optional: Assign a GameObject to this field if needed.")]
    [SerializeField] GameObject activateTriggerZone;

    private GhostController ghostController;
    private string ghostTag = "Ghost";


    private void Start()
    {
        ghostController = GameObject.FindGameObjectWithTag(ghostTag).GetComponent<GhostController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject);
            UnityEvent?.Invoke();
            if (activateTriggerZone != null)
            {
                activateTriggerZone.SetActive(true);
            }
            Destroy(gameObject);
        }
    }

    public void PlayIdleAnimation01() 
    {
        ghostController.IdleAnimation01();
    }

    public void PlayIdleAnimation02() 
    {
        ghostController.IdleAnimation02();
    }

    public void PlayIdleAnimation03()
    {
        ghostController.IdleAnimation03();
    }

    public void PlayWalkAnimation() 
    {
        ghostController.WalkAnimation01();
    }

    public void PlayChaseAnimation()
    {
        ghostController.ChaseAnimation01();
    }

    public void Deactivate() 
    {
        ghostController.Deactivate();
    }

}
