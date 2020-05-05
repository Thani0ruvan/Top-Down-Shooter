using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Asset", menuName = "Gun")]
public class Gun_Asset : ScriptableObject
{
    public enum Gun_Type
    {
        Rifle,
        Shotgun,
        Pistol
    }
    [SerializeField] private string Gun_Name;
    [SerializeField] private Gun_Type guntype;
    [SerializeField] private Sprite Gun_Sprite;
    [SerializeField] private GameObject Bullet_Prefab;


    [Space]

    [SerializeField] private int Damage_Rate;
    [SerializeField] private int Bullet_Rate;
    [SerializeField] private int Mag_Capacity;
    [SerializeField] private int Bullet_Velocity;
    [SerializeField] private float Reloading_Time;


    public string GunName()
    {
        return Gun_Name;
    }


    public string GunType()
    {
        return guntype.ToString();
    }

    public Sprite GunSprite()
    {
        return Gun_Sprite;
    }

    public GameObject BulletPrefab()
    {
        return Bullet_Prefab;
    }

    public int DamageRate()
    {
        return Damage_Rate;     
    }
    public int BulletRate ()
    {
        return Bullet_Rate;
    }

    public int MagCapacity()
    {
        return Mag_Capacity;
    }

    public int BulletVelocity()
    {
        return Bullet_Velocity;
    }

    public float ReloadingTime()
    {
        return Reloading_Time;
    }
}
