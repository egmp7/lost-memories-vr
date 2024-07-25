using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] Transform Player ;
    [SerializeField] [Range(0.5f, 1.5f)]float frequency = 1.0f;

    private Vector3 _tempPosition;
    private AudioSource _audioSource;
    
    void Start()
    {
        _tempPosition = Player.position;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 tempPos = new Vector2(_tempPosition.x, _tempPosition.z);
        Vector2 playerPos = new Vector2(Player.position.x, Player.position.z); 

        float distance = Vector2.Distance(tempPos, playerPos); 

        if (distance > frequency)
        {
            _audioSource.Play();
            _tempPosition = Player.position;
        }
    }
}

