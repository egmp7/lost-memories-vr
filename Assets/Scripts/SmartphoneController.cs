using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SmartphoneController : MonoBehaviour
{
    public delegate void CreepyPhoneCall();
    static public event CreepyPhoneCall onCreepyPhoneCall;
    
    [Header("Clips")]
    [SerializeField] AudioClip soundClip00;  // The sound clip to be played
    [SerializeField] AudioClip soundClip01;  // The sound clip to be played

    [Header("Sound")]
    [SerializeField] float MasterVolume = 1.0f;
    [SerializeField] float triggerDelay = 5f;  // Time in seconds before the sound starts
    [SerializeField] float releaseTimeBetweenCalls = 3f;
    [SerializeField] float soundDuration = 3f;  // Duration for which the sound should loop
    [SerializeField] float maxDistance = 50f;  // Maximum distance for fading effect

    private AudioSource audioSource;
    private bool isPhoneRinging = false;
    private bool isPhonePickedUp = false;
    private bool isClip01Playing = false;
    private Transform playerTransform;  // Reference to the player's transform

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip00;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(PlaySoundAfterDelay());
    }

    void Update()
    {
        DistanceRangeVolume();
        CheckIfSoundClip01Ended();
    }

    public void AnswerPhoneCall()
    {
        if (isPhoneRinging && !isPhonePickedUp)
        {
            AudioClip newClip = soundClip01;
            if (newClip == null) Debug.Log("no clip");
            else
            {
                audioSource.clip = newClip;
                audioSource.loop = false;
                audioSource.Play();

                StopAllCoroutines();
                isPhonePickedUp = true;
                isClip01Playing = true;
            }
        }
    }

    IEnumerator PlaySoundAfterDelay()
    {
        yield return new WaitForSeconds(triggerDelay);
        isPhoneRinging = true;
        audioSource.Play();

        StartCoroutine(StopSoundAfterDuration());
    }

    IEnumerator PlaySoundAfterTimeRelease()
    {
        yield return new WaitForSeconds(releaseTimeBetweenCalls);
        isPhoneRinging = true;
        audioSource.Play();

        StartCoroutine(StopSoundAfterDuration());
    }

    IEnumerator StopSoundAfterDuration()
    {
        yield return new WaitForSeconds(soundDuration);
        isPhoneRinging = false;
        if (audioSource.clip == soundClip00)
        {
            audioSource.Stop();
        }
        StartCoroutine(PlaySoundAfterTimeRelease());
    }

    private void DistanceRangeVolume()
    {
        if (audioSource.isPlaying)
        {
            float distance = Vector3.Distance(playerTransform.position, transform.position);
            float volume = 1 - Mathf.Clamp01(distance / maxDistance);
            audioSource.volume = volume * MasterVolume;
        }
    }

    private void CheckIfSoundClip01Ended()
    {
        if (isClip01Playing && !audioSource.isPlaying)
        {
            Debug.Log("Clip 01 Ended");
            isClip01Playing = false;
            onCreepyPhoneCall?.Invoke();
            // next scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
