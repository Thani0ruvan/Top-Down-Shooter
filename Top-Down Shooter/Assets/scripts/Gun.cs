using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Gun : MonoBehaviour
{

    enum State
    {
        Shooting,
        Reloading
    }
    State CurrentState;

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
        CurrentState = State.Shooting;

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
        Debug.Log(my_gun.GunType() + "Eq");
        anim.SetBool(my_gun.GunType() + "Eq", true);

        StartingGun = my_gun.GunName();
        if (StartingGun != EndingGun) { SetGun(); StartCoroutine(SetAnim()); SetGunValue(); }

        switch (CurrentState)
        {
            case State.Shooting:


                transform.position = GameObject.Find(my_gun.GunType() + "_SpawnPoint").transform.position;

                if (Input.GetMouseButton(0)) Shoot();


                if (BulletTimeGap > 0)
                {
                    BulletGap();
                }


                 if (RemainingBullet <= 0)
                {
                    StartCoroutine(Reload());
                }
               

                if (Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine( Reload());
                }
                break;


         
              
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

   public IEnumerator SetAnim() {

        anim.SetBool("Idle",true);

        yield return new WaitForSeconds(1f);

        anim.SetBool("Idle",false);

        


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

    IEnumerator Reload()
    {
        CurrentState = State.Reloading;

        yield return new WaitForSeconds(ReloadTime);
       

            RemainingBullet = MaxBullet;
            CurrentState = State.Shooting;
        
    }
}
