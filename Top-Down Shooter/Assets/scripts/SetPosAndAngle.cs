using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyClass;

public class SetPosAndAngle : MonoBehaviour
{
     LineOfSight1 los;
    public sender send;
   
    // Start is called before the first frame update
    void Start()
    {
        los = LineOfSight1.GetLOS();
    }

    // Update is called once per frame
    void Update()
    {
        los.SetOrigin(transform.position);
        los.SetAim(Maths.Calculate.VectorFor(GetComponent<Rigidbody2D>().rotation));

        send.SetOrigrin(transform.position);
        send.SetAim(Maths.Calculate.VectorFor(GetComponent<Rigidbody2D>().rotation));
        
    }
}
