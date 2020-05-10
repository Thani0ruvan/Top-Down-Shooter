using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace MyClass 
{
   class AI
   {
       
    
   }

    class Movement
    {
        public static Vector2 MoveTo(Rigidbody2D source,Rigidbody2D target,float speed)
        {
           return Vector2.MoveTowards(source.position, target.position, speed);
        }

        public static float AimTo(Vector2 origin,Vector2 PointToAim ,float Offset=0)
        {
            Vector2 lookDir = PointToAim - origin;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            float AimAngle = angle + Offset;
            return AimAngle;
        }
    }
    class Maths
    {
       public static class Calculate
        {
            public static Vector3 VectorFor(float angle)
            {
                float AngleRad = angle * (Mathf.PI / 180f);
                return new Vector3(Mathf.Cos(AngleRad), Mathf.Sin(AngleRad));
            }
            public static float AngleFor(Vector3 dir)
            {
                dir = dir.normalized;
                float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                if (n < 0) n += 360;
                return n;
            }
            public static float Rand(float MinValue, float MaxValue)
            {
                return Random.Range(MinValue, MaxValue);
            }
        }
    }
    class text
    {
        public static TextMesh CreateWorldText(Transform parent,string text ,Vector3 localPos,int fontSize,Color color,TextAnchor textAnchor,TextAlignment textAlignment,int sortinglayer)
        {
            GameObject gameObject = new GameObject("World_text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPos;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortinglayer;
            return textMesh;


        }
    }

}
