using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyClass;

public class Blood : MonoBehaviour
{
    SpriteRenderer sr;

    float Darkness;
    float Size;
    float Rotate;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        Darkness = Maths.Calculate.Rand(100, 255);
        Size = Maths.Calculate.Rand(1, 4);
        Rotate = Maths.Calculate.Rand(0,360);

        sr.color = new Color(Darkness, Darkness, Darkness, 1);
        transform.localScale = new Vector3(Size, Size, 1);
        transform.rotation = Quaternion.Euler(0, 0, Rotate);
    }

   
   
}
