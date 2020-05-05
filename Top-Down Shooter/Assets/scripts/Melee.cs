using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    Transform player;
    public LayerMask target;
    void Start()
    {
       player= GameObject.FindGameObjectWithTag("Player").transform;
            }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MeleeAttack();
        } 
    }
    void MeleeAttack()
    {
        Collider2D[] enemiesToAttack= Physics2D.OverlapCircleAll(player.position, 1f,target);
        foreach(Collider2D enemyToAttack in enemiesToAttack)
        {
         Enemy enemy=    enemyToAttack.GetComponent<Enemy>();
            enemy.TakeDamage(50);
        }
    }
}
