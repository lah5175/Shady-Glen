using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int magic = 100;
    public string weapon = "Sword";
    public int attack = 0;
    public int defense = 0;

    public bool isBurning = false;
    public bool isPoisoned = false;
    public bool isDead = false;

    void Update()
    {
        if (health > 100) health = 100;
        if (health < 0) health = 0;
    }
}
