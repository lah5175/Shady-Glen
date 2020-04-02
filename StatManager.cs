using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public Text health;
    public Text magic;
    public PlayerStats player;
    public GameObject sword;
    public GameObject bow;

    float timer = 0;

    // Sets the burning status on the player character
    public void BurningStatus(bool burning)
    {
        player.isBurning = burning;
    }

    // Deals damage to the player
    public void DealDamage(int damage)
    {
        player.health -= damage;
    }

    void Update()
    {
        // Deals with damage over time

        timer += Time.deltaTime;

        if (player.isBurning && timer >= 1f)
        {
            player.health -= 10;
        }

        health.text = player.health.ToString();
        magic.text = player.magic.ToString();

        // Allows the player to switch between weapons

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.weapon = "Sword";
            bow.SetActive(false);
            sword.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.weapon = "Bow";
            sword.SetActive(false);
            bow.SetActive(true);
        }

        if (timer >= 1f) timer = 0f;  // Resets timer used for DoT ticks
    }
}
