using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamaraManager : MonoBehaviour
{
    static Camera _instance;

    private void Awake()
    {
        _instance = GetComponent<Camera>();
    }

    public static Camera GetMainCam()
    {
        return _instance;
    }
}
