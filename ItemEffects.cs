using UnityEngine;
using UnityEngine.Events;

public class ItemEffects : MonoBehaviour
{
    public PlayerStats player;

    public static ItemEffects instance;

    void Awake()
    {
        if (instance != null) Debug.LogWarning("More than one instance of item effects found!");
        instance = this;
    }

    public UnityAction UseItem(string name)
    {
        switch (name)
        {
            case "Health Potion":
                return HealThirty;
            case "Antidote":
                return HealPoison;
            case "Revive":
                return Revive;
            default:
                return null;
        }
    }

    void HealThirty()
    {
        player.health += 30;
    }

    void HealPoison()
    {
        player.isPoisoned = false;
    }

    void Revive()
    {
        player.isDead = false;
    }
}
