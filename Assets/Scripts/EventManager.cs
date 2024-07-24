using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    // Subscribe 
    private void OnEnable()
    {
        SmartphoneController.onCreepyPhoneCall += LoadNextScene;
    }
    // Unsubscribe
    private void OnDisable()
    {
        SmartphoneController.onCreepyPhoneCall -= LoadNextScene;
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
