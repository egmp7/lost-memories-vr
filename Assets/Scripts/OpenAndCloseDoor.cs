using System.Collections;
using UnityEngine;

public class OpenAndCloseDoor : MonoBehaviour
{
    [SerializeField] bool isDoorOpen;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerDoor()
    {
        if (isDoorOpen) 
        {
            StartCoroutine (closing());
        }
        else
        {
            StartCoroutine (opening());
        }
    }

    IEnumerator opening()
    {
        print("you are opening the door");
        animator.Play("Opening");
        isDoorOpen = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        animator.Play("Closing");
        isDoorOpen = false;
        yield return new WaitForSeconds(.5f);
    }

}
