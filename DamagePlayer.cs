using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;
    public StatManager statManager;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player") statManager.BurningStatus(true);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player") statManager.BurningStatus(false);
    }
}
