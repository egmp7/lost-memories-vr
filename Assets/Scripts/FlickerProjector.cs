using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerProjector : MonoBehaviour
{
    [Header("Customize")]
    [Tooltip("Interval between flickers")]
    [SerializeField ] [Range(0,0.5f)] float FlickerInterval = 0.1f;
    [Tooltip("Probability of flickering in each frame")]
    [SerializeField] [Range(0, 1)] float FlickerChance = 0.1f;
    [SerializeField] bool ProjectorEnabled = true;
    [SerializeField] bool IsProjectorOn = true;
    
    private DecalProjector projector;
    private AudioSource flickerAudioSource;
    private float timer = 0f;

    private void OnEnable()
    {
        FlashlighController.onFlashlightPick += ProjectorOff;
    }

    private void OnDisable()
    {
        FlashlighController.onFlashlightPick -= ProjectorOff;
    }

    private void Awake()
    {
        projector = GetComponent<DecalProjector>();
        flickerAudioSource = GetComponent<AudioSource>();

        if (projector == null) Debug.Log("Projector not loaded");
        if (flickerAudioSource == null) Debug.Log("Audio Source not loaded");
    }

    private void Start()
    {
        projector.enabled = IsProjectorOn;
    }

    private void Update()
    {
        if (ProjectorEnabled) Flicker();
        else projector.enabled = ProjectorEnabled;
    }

    private void Flicker()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // If the timer exceeds the interval
        if (timer >= FlickerInterval)
        {
            //// Flicker
            ///
            // Randomly decide whether to flicker
            if (Random.value < FlickerChance)
            {
                // Toggle the state of the object
                IsProjectorOn = !IsProjectorOn;
                projector.enabled = IsProjectorOn;
            }

            // Reset the timer
            timer = 0f;
        }
    }

    private void ProjectorOff()
    {
        gameObject.SetActive(false);
        flickerAudioSource.Stop();
    }


}
