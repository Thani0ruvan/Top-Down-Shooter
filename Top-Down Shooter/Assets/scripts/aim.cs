using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
     
    public float offset = 0f;
     Camera MainCam;
     Rigidbody2D playerRB;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = PlayerManager.GetPlayerComp<Rigidbody2D>();
        MainCam = MainCamaraManager.GetMainCam();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos=  MainCam.ScreenToWorldPoint(Input.mousePosition);
       
    }
    void LateUpdate()
    {
        Vector2 lookDir = mousePos - playerRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        playerRB.rotation = angle+offset;
        
    }
}
