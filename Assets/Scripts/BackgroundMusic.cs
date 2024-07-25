using System.Collections;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource nextAudioSource1; // External AudioSource 1
    [SerializeField] private AudioSource nextAudioSource2; // External AudioSource 2
    [SerializeField] private AudioSource nextAudioSource3; // External AudioSource 3
    [SerializeField] private float crossfadeDuration = 2.0f; // Duration of the crossfade in seconds

    private AudioSource currentAudioSource; // The AudioSource on this GameObject
    private bool isCrossfading = false;

    private void Start()
    {
        currentAudioSource = GetComponent<AudioSource>();
        StartCoroutine(CheckForCrossfade());
    }

    private IEnumerator CheckForCrossfade()
    {
        while (true)
        {

            if (!isCrossfading && currentAudioSource.isPlaying)
            {
                float remainingTime = currentAudioSource.clip.length - currentAudioSource.time;
                if (remainingTime <= crossfadeDuration)
                {
                    StartCoroutine(Crossfade());
                    isCrossfading = true;
                }
            }
            yield return null;
        }
    }

    private IEnumerator Crossfade()
    {
        float startTime = Time.time;
        float endTime = startTime + crossfadeDuration;

        // Ensure external audio sources are set to volume 0 and start playing them if they are assigned
        if (nextAudioSource1 != null) nextAudioSource1.volume = 0;
        if (nextAudioSource2 != null) nextAudioSource2.volume = 0;
        if (nextAudioSource3 != null) nextAudioSource3.volume = 0;
        // Play all three external audio sources if they are assigned
        if (nextAudioSource1 != null) nextAudioSource1.Play();
        if (nextAudioSource2 != null) nextAudioSource2.Play();
        if (nextAudioSource3 != null) nextAudioSource3.Play();

        // Gradually decrease the volume of the current audio source and increase the volume of the new audio sources if they are assigned
        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / crossfadeDuration;

            currentAudioSource.volume = Mathf.Lerp(1, 0, t);

            if (nextAudioSource1 != null) nextAudioSource1.volume = Mathf.Lerp(0, 1, t);
            if (nextAudioSource2 != null) nextAudioSource2.volume = Mathf.Lerp(0, 1, t);
            if (nextAudioSource3 != null) nextAudioSource3.volume = Mathf.Lerp(0, 1, t);

            yield return null;
        }

        // Ensure volumes are set to final values after crossfade duration
        currentAudioSource.volume = 0;

        if (nextAudioSource1 != null) nextAudioSource1.volume = 1;
        if (nextAudioSource2 != null) nextAudioSource2.volume = 1;
        if (nextAudioSource3 != null) nextAudioSource3.volume = 1;
    }
}
