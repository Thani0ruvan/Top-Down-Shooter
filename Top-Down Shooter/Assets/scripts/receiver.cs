using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receiver : MonoBehaviour
{
    public GameObject Mymask;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<sender>())
        {
            Debug.Log("It");
            Mymask.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.GetComponent<sender>())
        {
            Mymask.SetActive(false);
        }
    }
    
}
