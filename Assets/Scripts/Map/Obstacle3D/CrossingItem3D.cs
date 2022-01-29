using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Controller;
using UnityEngine;

public class CrossingItem3D : MonoBehaviour
{
    public Animator _anim;

    private void Start()
    {
        _anim.speed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Runner>())
        {
            _anim.speed = 1;
        }
    }
}
