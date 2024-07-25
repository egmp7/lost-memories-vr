using UnityEngine;

public class FlashlighController : MonoBehaviour
{
    public delegate void FlashlightPick();
    static public event FlashlightPick onFlashlightPick;

    [SerializeField] Light Spotlight;
    [SerializeField] AudioClip FlashlightOnClip;
    [SerializeField] AudioClip FlashlightOffClip;

    private bool isFlashlightPicked = false;
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
        if (!isFlashlightPicked)
        {
            isFlashlightPicked = !isFlashlightPicked;
            onFlashlightPick.Invoke();
        }

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
        if (! isFlashlightPicked)
        {
            isFlashlightPicked = !isFlashlightPicked;
            onFlashlightPick.Invoke();
        }
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
