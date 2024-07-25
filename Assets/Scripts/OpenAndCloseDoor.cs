using System.Collections;
using UnityEngine;

public class OpenAndCloseDoor : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] bool isDoorOpen;

    [Header("Audio")]
    [SerializeField] AudioClip openDoorSound;
    [SerializeField] AudioClip closeDoorSound;

    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        // Play opening animation
        animator.Play("Opening");

        // Play open door sound
        if (audioSource != null && openDoorSound != null)
        {
            audioSource.clip = openDoorSound;
            audioSource.Play();
        }

        isDoorOpen = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        // Play closing animation
        animator.Play("Closing");
        // Play close door sound
        if (audioSource != null && closeDoorSound != null)
        {
            audioSource.clip = closeDoorSound;
            audioSource.Play();
        }
        isDoorOpen = false;
        yield return new WaitForSeconds(.5f);
    }

}
