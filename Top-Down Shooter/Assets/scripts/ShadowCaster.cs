using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCaster : MonoBehaviour
{
    Vector3 origin;
    GameObject[] shadowObj;
    string[] names;
    int i = 0;   
    void Start()
    {
        names = new string[10] { "0","0","0","0","0","0","0","0","0","0"};
        shadowObj = new GameObject[10];
        
       
    }

    // Update is called once per frame
    void Update()
    {
         origin = transform.position;

    }
   
    public void CreateShadow(int index,GameObject mylight)
    {
        shadowObj[index] = Instantiate(new GameObject("Shadow Of " + mylight.name, typeof(SpriteRenderer), typeof(Shadow)), transform);
        
        SpriteRenderer sr = shadowObj[index].GetComponent<SpriteRenderer>();
        Shadow shadow = shadowObj[index].GetComponent<Shadow>();
        sr.sprite = GetComponent<SpriteRenderer>().sprite;
        sr.sortingOrder = -1;
        shadowObj[index].layer= gameObject.layer;
        shadow.Getlightandobject(mylight, gameObject);
        sr.color = Color.black;

        shadowObj[index].transform.position = transform.position;
    }


    public void MyShadow(GameObject mylight)
    {
        name = mylight.name;
        bool MyChance = true;
        if (names != null)
        {
            for (int i = 1; i < names.Length; i++)
            {
                if (name == names[i])
                {
                    MyChance = false;
                }
            }

            if (MyChance)
            {
                CreateShadow(i, mylight);
                MyChance = false;


                names[i] = name;
                i++;

            }
        }
    }
}
