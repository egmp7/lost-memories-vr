using System.Collections;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] float triggerDelay = 5f;  // Time in seconds before the sound starts
    [SerializeField] float maxDistance = 20f;  // Maximum distance for fading effect

    private AudioSource audioSource;
    private bool isRadioPlaying = false;
    private GameObject player;

void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(PlaySoundAfterDelay());
    }

    void Update()
    {
        DistanceRangeVolume();
    }

    public void Interact()
    {
        if (isRadioPlaying)
        {
            audioSource.Pause();
            isRadioPlaying = false;
        }
        else
        {
            audioSource.Play();
            isRadioPlaying = true;
        }
        StopAllCoroutines();
    }

    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(triggerDelay);
        isRadioPlaying = true;
        audioSource.Play();
    }

    private void DistanceRangeVolume()
    {
        if (audioSource.isPlaying)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            float volume = 1 - Mathf.Clamp01(distance / maxDistance);
            audioSource.volume = volume;
        }
    }
}
