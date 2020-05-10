using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] Transform AttackPoint;
    [SerializeField] float AttackRange;
    [SerializeField] LayerMask EnemyLayer;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("We Pressed Mouse1");
            Attack();
        } 
    }
    void Attack()
    {

        GetComponent<Animator>().SetTrigger("Melee");

       Collider2D[] Enemies= Physics2D.OverlapCircleAll(AttackPoint.position,AttackRange,EnemyLayer);

        foreach(Collider2D Detectedenemy in Enemies)
        {
            Debug.Log("We Dedect"+Detectedenemy.name);

            Detectedenemy.GetComponent<Enemy>().TakeDamage(50);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
