using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyClass;

public class Enemy : MonoBehaviour
{
    #region Data
    [SerializeField]EnemySO MyData;

    [Header("Datas", order = 0)]
    int Health;
    int HitPoints;
    float Speed;

    void SetData()
    {
        Health = MyData.Health;
        HitPoints = MyData.HitPoints;
        Speed = MyData.Speed;
    }

    #endregion
   #region Health
    [Header("HealthSystem",order =1)]
    int MyMaxHealth;
    int MyHealth;

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
    #endregion
    #region Melee
    [Header("MeleeSystem",order =2)]
    Rigidbody2D myrb;
    Rigidbody2D playerrb;
   
    IEnumerator EnemyMeleeAttack()
    {
        yield return new WaitForSeconds(2f);
        Collider2D PlayerToAttack = Physics2D.OverlapCircle(myrb.position, 5f);

        if (PlayerToAttack.GetComponent<PlayerHealthSystem>() != null )
        {
            PlayerHealthSystem PlayerHealth = PlayerToAttack.GetComponent<PlayerHealthSystem>();
            PlayerHealth.TakeDamage(HitPoints);
        }
    }

    #endregion

    void Awake()
    {   
        //Data
        SetData();

        //Health
        MyHealth = MyMaxHealth=Health;

        //follow and Melee
        myrb = GetComponent<Rigidbody2D>();
         }
    private void Start()
    {
          playerrb = PlayerManager.GetPlayerComp<Rigidbody2D>();
 
    }

    void Update()
    {


        if (Vector2.Distance(myrb.position, playerrb.position) < 4f)
        {
            EnemyMeleeAttack();
        }
        
            myrb.position = Movement.MoveTo(myrb, playerrb, Speed * 0.01f);
       
    }

   


   
}
