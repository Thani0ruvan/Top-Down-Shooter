using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.GetComponent<Enemy>()!=null)
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(10);
        }
    }
}
