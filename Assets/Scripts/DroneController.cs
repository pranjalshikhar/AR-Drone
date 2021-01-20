﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    Animator _Anim;

    Vector3 _Speed = new Vector3(0.0f, 0.0f, 0.0f);

    public float _SpeedMultiplyer = 1.0f;

    void Start()
    {
        _Anim = GetComponent<Animator>();
        _Anim.SetBool("TakeOff", true); 
    }

    public void Move(float _speedX, float _speedZ)
    {
        _Speed.x = _speedX;
        _Speed.z = _speedZ;

        UpdateDrone();
    }

    void UpdateDrone()
    {
        transform.localPosition += _Speed * _SpeedMultiplyer * Time.deltaTime;
    }
}
