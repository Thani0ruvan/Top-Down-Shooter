using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lighter : MonoBehaviour
{
    
    float radius;
    List<RaycastHit2D> rchList;

    List<ShadowCaster> caster;
    private void Start()
    {
        GetComponent<Light2D>().pointLightOuterRadius = 10f;
        radius = GetComponent<Light2D>().pointLightOuterRadius;

        rchList = new List<RaycastHit2D>();
        caster = new List<ShadowCaster>();
    }
    void Update()
    {
       RaycastHit2D[] rch = Physics2D.CircleCastAll(transform.position, radius, Vector2.right);

        AddList(rch,rchList);
    
        for(int i = 0; i < rchList.Count; i++)
        {
            //check for presence of ShadowCaster
            ShadowCaster sc = rchList[i].collider.GetComponent<ShadowCaster>();


            if (sc != null)
            {
               
                caster.Add(rchList[i].collider.GetComponent<ShadowCaster>());
                
                caster[i].MyShadow(gameObject);
                
            }
        }
    }

    void AddList<T>(T[] raycast ,List<T> list)
    {
        foreach(T t in raycast)
        {
            list.Add(t);
        }
    }
}
