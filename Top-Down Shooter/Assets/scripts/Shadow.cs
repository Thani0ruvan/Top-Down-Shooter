using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Shadow : MonoBehaviour
{
    bool IsObjObt=false;
    GameObject myobj;
    Lighter mylight;
    public float divider=5f;
   
   
    private void Start()
    {
       
       
    }

    private void Update()
    {
        if (IsObjObt)
        {
            Vector3 LightPos = mylight.transform.position;
            Vector3 ObjPos = myobj.transform.position;

            UpdatePos(UpdateAngle(LightPos, ObjPos));
            UpdateStrenght();
        }   
    
    
    
    }
    public void Getlightandobject(GameObject light,GameObject obj)
    {
        mylight = light.GetComponent<Lighter>();
        myobj = obj;
        IsObjObt = true;

    }

    Vector3 UpdateAngle(Vector3 LightPos,Vector3 ObjPos)
    {


        Vector3 Incomedir = LightPos - ObjPos;


        Incomedir = Incomedir.normalized;
        /* float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
         if (n < 0) n += 360;
         Debug.Log(n);*/

        Vector3 OutGoindDir = -(Incomedir);

        return OutGoindDir;
    }

    void UpdatePos(Vector3 dir)
    {
       float dis=Mathf.Clamp01( GetDistance());
        transform.position = myobj.transform.position + ((dir * dis)/2);

        float size =Mathf.Pow( GetDistance(),1/divider);

        transform.localScale = new Vector3(size,size);
        
    }

    void UpdateStrenght()
    {
        Light2D light =this.mylight.GetComponent<Light2D>();
        SpriteRenderer sr=GetComponent<SpriteRenderer>();

       float strenght= light.intensity;

        sr.color =new Color(0,0,0,strenght /3);

        
    }

    float GetDistance()
    {
       float Distance= Vector2.Distance(transform.position, mylight.transform.position);

       // Debug.Log(Distance);
       
        return Distance;
    }
}

