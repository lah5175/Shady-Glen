using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    RaycastHit hit;
    public float distance = 100f;
    public float drawStrength = 0f;
    public float damage = 10f;
    public float drawTime = 2f;
    public AudioSource drawSFX;
    public AudioSource shootSFX;
    public PlayerStats player;
    public GameObject sword;
    public GameObject bow;

    Animator swordAnim;
    Animator bowAnim;

    float timer = 0;

    void Start()
    {
        swordAnim = sword.GetComponent<Animator>();
        bowAnim = bow.GetComponent<Animator>();
    }

    void ToggleSwordAnim ()
    {
        swordAnim.SetBool("SwordSwing", false);
    }
    
    void Update()
    {
        if (player.weapon == "Bow")
        {
            timer += Time.deltaTime;

            Debug.DrawRay(this.transform.position, this.transform.forward * distance, Color.cyan);

            if (Input.GetButton("Fire1"))
            {
                if (drawStrength == 0)
                {
                    drawSFX.Play();
                    bowAnim.SetBool("isShooting", true);
                }
                if (timer >= 0.1f && drawStrength < 1f)
                {
                    drawStrength += 0.1f;
                }
            }


            if (Input.GetButtonUp("Fire1"))
            {
                shootSFX.Play();
                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distance, 9) && hit.collider.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyDamage>().TakeDamage(damage * drawStrength);
                }

                drawStrength = 0f;
                timer = 0;
                bowAnim.SetBool("isShooting", false);
            }

            if (timer >= 0.1f) timer = 0;
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && !swordAnim.GetBool("SwordSwing"))
            {
                swordAnim.SetBool("SwordSwing", true);
                Invoke("ToggleSwordAnim", .4f);
            }
        }
    }
}
