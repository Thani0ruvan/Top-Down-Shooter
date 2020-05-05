﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Gun : MonoBehaviour
{
    [SerializeField] Gun_Asset my_gun;
    [SerializeField] Animator anim;

    GameObject bulletprefab;
    public Transform BulletSpawnpoint;
    Transform GunPosition;

    
    int MaxBullet;
    int RemainingBullet;

    int bulletvelocity;

    float BulletTimeGap;
    float resetGap;

    float ReloadTime;
    float ResetReloadTime;

     string StartingGun;
     string EndingGun;

    
    private void Awake()
    {
        StartingGun = my_gun.GunName();
        EndingGun = StartingGun;

         }
    void Start()
    {
        

        SetGun();
        StartCoroutine(SetAnim());
        SetGunValue();


    }


    void Update()
    {
        Debug.Log(my_gun.GunType() + "_Eq");
       

         StartingGun = my_gun.GunName();
        if (StartingGun != EndingGun) { SetGun(); StartCoroutine(SetAnim()); SetGunValue(); }

            transform.position = GameObject.Find(my_gun.GunType()+"_SpawnPoint").transform.position;

        if (Input.GetMouseButton(0)) Shoot();

         
        if (BulletTimeGap > 0)
        {
            BulletGap();
        }


        if (RemainingBullet <= 0)
        {
            Reload();
        }

        EndingGun = my_gun.GunName();
        if (StartingGun != EndingGun) { SetGun(); StartCoroutine(SetAnim()); SetGunValue(); }
       
    } 
    void SetGun()
    {

        GetComponent<SpriteRenderer>().sprite = my_gun.GunSprite();
        bulletprefab = my_gun.BulletPrefab();

        bulletvelocity = my_gun.BulletVelocity();

    }

    void SetGunValue() {

        MaxBullet = my_gun.MagCapacity();
        RemainingBullet = MaxBullet;

        BulletTimeGap = 1 / my_gun.BulletRate();
        resetGap = BulletTimeGap;

        ReloadTime = my_gun.ReloadingTime();
        ResetReloadTime = ReloadTime;
    }

    IEnumerator SetAnim() {

        anim.SetBool("Idle",true);

        yield return new WaitForSeconds(1f);

        anim.SetBool("Idle",false);

        anim.SetTrigger(my_gun.GunType() + "_Eq");


    }


    public void Shoot()
    {
        if (RemainingBullet > 0)
        {
            if (BulletTimeGap <= 0)
            {
                Spawn();
                RemainingBullet--;
                BulletTimeGap = resetGap;
            }
           
            
        }
       
    }

    void BulletGap()
    {
        BulletTimeGap -= Time.deltaTime;
    }
    void Spawn()
    {
        GameObject bullet = Instantiate(bulletprefab, BulletSpawnpoint.position, transform.rotation);
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
        //bulletrb.velocity = Vector2.up * bulletvelocity;
        bulletrb.AddForce(BulletSpawnpoint.right * bulletvelocity, ForceMode2D.Impulse);

    }

    void Reload()
    {
        if (ReloadTime > 0)
        {
            ReloadTime -= Time.deltaTime;
        }
        else
        {
            RemainingBullet = MaxBullet;
            ReloadTime = ResetReloadTime;
        }
    }
}
