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

    Animator anim;
    [SerializeField]LayerMask PlayerLayer;

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
        Debug.Log("Im Enemy Died");

        SpawnEnemy.GetInstance().EnemyAliveList.Remove(this);


        Instantiate(SpawnEnemy.GetInstance().bloodEff, transform.position+new Vector3(0,0,0),Quaternion.identity);

        //  this.GetComponent<SpriteRenderer>().enabled = false;
        //  this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        //  this.GetComponent<CircleCollider2D>().enabled = false;

        this.gameObject.SetActive(false);

        this.enabled = false;
    }
    #endregion
    #region Melee
    [Header("MeleeSystem",order =2)]
    Rigidbody2D myrb;
    Rigidbody2D playerrb;
   

   
    void TriggerAttack()
    {
        Collider2D PlayerToAttack = Physics2D.OverlapCircle(myrb.position, 5f, PlayerLayer);

        if (PlayerToAttack != null)
        { 
            PlayerHealthSystem playerHealthSystem = PlayerToAttack.GetComponent<PlayerHealthSystem>();
            Debug.Log("Attack");
            PlayerHealthSystem PlayerHealth = PlayerToAttack.GetComponent<PlayerHealthSystem>();
            PlayerHealth.TakeDamage(HitPoints);
        }
    }

    #endregion
    #region AimPlayer
    void AimPlayer()
    {

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

        anim = GetComponent<Animator>();
         }
    private void Start()
    {
          playerrb = PlayerManager.GetPlayerComp<Rigidbody2D>();
 
    }

    void Update()
    {

        if (Vector2.Distance(myrb.position, playerrb.position) > 4f)
        {

            myrb.position = Movement.MoveTo(myrb, playerrb, Speed * 0.01f);
        }
        else 
        {
            anim.SetTrigger("IsAttack");

        }

        myrb.rotation=MyClass.Movement.AimTo(myrb.position, playerrb.position, 0);
    }

   


   
}
