using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.GetComponent<Enemy>()!=null)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(10);
        }
    }
}
