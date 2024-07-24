using UnityEngine;

public class FlashlighController : MonoBehaviour
{
    [SerializeField] Light Spotlight;
    [SerializeField] AudioClip FlashlightOnClip;
    [SerializeField] AudioClip FlashlightOffClip;

    private AudioSource audioSource;
    private bool isFlashlightActive = false;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        Spotlight.enabled = false;
    }

    public void FlashlightON()
    {
        if (!isFlashlightActive)
        {
            Spotlight.enabled = true;
            isFlashlightActive = true;
            PlayAudioClip(FlashlightOnClip);
        }
    }

    public void FlashlightOFF()
    {
        if (isFlashlightActive)
        {
            Spotlight.enabled = false;
            isFlashlightActive = false;
            PlayAudioClip(FlashlightOffClip);
        }
    }

    public void ToggleFlashlight()
    {
        isFlashlightActive = !isFlashlightActive;
        Spotlight.enabled = isFlashlightActive;
        PlayAudioClip(isFlashlightActive ? FlashlightOnClip : FlashlightOffClip);
    }

    private void PlayAudioClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
