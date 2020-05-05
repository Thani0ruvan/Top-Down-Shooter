using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    int MyMaxHealth = 100;
    int MyHealth;

    private void Start()
    {
        MyHealth = MyMaxHealth;
    }

    public void TakeDamage(int damage)
    {
        MyHealth -= damage;
        if (MyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Im Died");
    }
}
