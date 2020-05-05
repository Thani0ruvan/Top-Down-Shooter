using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static GameObject _instance;

    private void Awake()
    {
        _instance = this.gameObject;
    }

    public static GameObject GetPlayer()
    {
        return _instance;
    }
    public static T GetPlayerComp <T>()
    {
        return _instance.GetComponent<T>();
    }
}
