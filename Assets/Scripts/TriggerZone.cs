using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [Header("Dependencies")]
    [Tooltip("Optional: Assign a GameObject to this field if needed.")]
    [SerializeField] GameObject activateTriggerZone;

    private GhostController ghostController;
    private string gameObjectName;

    private string ghostTag = "Ghost";

    // Trigger Zones
    private string trigger01 = "Trigger01";
    private string trigger02 = "Trigger02";
    private string trigger03 = "Trigger03";
    private string trigger04 = "Trigger04";
    private string trigger05 = "Trigger05";
    private string trigger06 = "Trigger06";

    private void Start()
    {
        ghostController = GameObject.FindGameObjectWithTag(ghostTag).GetComponent<GhostController>();
        gameObjectName = gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObjectName == trigger01)
        {
            ghostController.IdleAnimation01();
        }

        if (gameObjectName == trigger02)
        {
            ghostController.WalkAnimation01();
        }

        if (gameObjectName == trigger03)
        {
            ghostController.IdleAnimation02();
        }

        if (gameObjectName == trigger04)
        {
            ghostController.ChaseAnimation01();
        }

        if (gameObjectName == trigger05)
        {
            ghostController.IdleAnimation03();
        }

        if (gameObjectName == trigger06)
        {
            ghostController.Deactivate();
        }

        if (activateTriggerZone != null) activateTriggerZone.SetActive(true);
        Destroy(gameObject);
    }
}
