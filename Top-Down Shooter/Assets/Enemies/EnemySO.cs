using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName ="EnemyAsset")]
public class EnemySO : ScriptableObject
{
    public enum EnemyType
    {
        Normal,
        Strong,
        Weak
    }

    public EnemyType enemytype;

    public int Health;

    public int HitPoints;

    public float Speed;


    


}
