using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    int MyMaxHealth = 100;
    int MyHealth;

    [SerializeField] Image BloodScreen;
    [SerializeField] Image RedScreen;

    private void Start()
    {
        MyHealth = MyMaxHealth;
    }

    public void TakeDamage(int damage)
    {
        MyHealth -= damage;
        d(MyHealth);
        if (MyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Im Died");
    }

   void d(int balanceHp)
    {
        float damaged = (float)(MyMaxHealth - balanceHp);
        float damagePercent=(damaged/ (float)MyMaxHealth);

        
        BloodScreen.color = new Color(BloodScreen.color.a, BloodScreen.color.g, BloodScreen.color.b, damagePercent);
        RedScreen.color = new Color(RedScreen.color.r, RedScreen.color.g, RedScreen.color.b, damagePercent / 4);
         
    }
}
