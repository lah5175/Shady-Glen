using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Enemy enemy;
    float hp;

    void Start()
    {
        hp = enemy.startingHP;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) Die();
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
