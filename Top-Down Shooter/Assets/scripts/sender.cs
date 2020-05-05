using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyClass;

public class sender : MonoBehaviour
{
    public float offset;
    
    float startingangle;
    


    PolygonCollider2D pc;
    Vector2 point0;
    Vector2 point1;
    Vector2 point2;
    Vector2 origin;
   
    private void Start()
    {
        pc = GetComponent<PolygonCollider2D>();
        pc.SetPath(0, new Vector2[] { Vector2.zero, Vector2.right, Vector2.down });
        // pc.points = new Vector2[] { Vector2.zero, Vector2.right, Vector2.down };
    }
    private void LateUpdate()
    {
        point0 = origin;

        point1 = Maths.Calculate.VectorFor(startingangle + 134)* 55;


        point2 = Maths.Calculate.VectorFor(startingangle - 90 + 134) * 55;

        pc.SetPath(0, new Vector2[] { point0, point1, point2 });



    }
    public void SetAim(Vector3 Dir)
    {
        startingangle = Maths.Calculate.AngleFor(Dir);

    }
    public void SetOrigrin(Vector2 origin)
    {
        this.origin = origin;
    }




}