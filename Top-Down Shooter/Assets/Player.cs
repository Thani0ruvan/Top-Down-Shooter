using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Movement

    [SerializeField] float speed = 1f;
    Vector2 move;
    Rigidbody2D rb;

    void GetMoveVector()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

    }
    void MoveVector()
    {
        rb.velocity = move.normalized * speed;
    }
    #endregion

    #region Aim
    [SerializeField] float offset = 0f;
    [SerializeField]Camera MainCam;
    Rigidbody2D playerRB;
    Vector2 mousePos;

    void Aim()
    {
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        rb.rotation=MyClass.Movement.AimTo(rb.position, mousePos,offset);
    }


    #endregion


    private void Awake()
    {
        //Movement
        rb = GetComponent<Rigidbody2D>();

       


    }
    void Start()
    {

    }

    private void Update()
    {
        //Movement
        GetMoveVector();
    }

    private void FixedUpdate()
    {
        //Movement
        MoveVector();
    }

    void LateUpdate()
    {
        //Aim
        Aim();

    }
}
