using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Controller;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Helicopter3D : Obstacle3D
{
    #region Properties

    private SphereCollider _sphereCollider;
    public float MalusValue;
    public bool IsSlowingRunner;
    private Collider _runner;
    public bool IsLightOn;
    public Vector3 CameraTransform = new Vector3(0,15,0);
    private float _defaultMoveSpeed = 0;
    
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("oui");
        _sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSlowingRunner)
        {
            _runner.gameObject.GetComponent<Runner>().moveSpeed = MalusValue;
        }
        else if(_defaultMoveSpeed != 0)
        {
            Debug.Log(_defaultMoveSpeed);
        }

        if (IsLightOn)
        {
            if(transform.position.y >= CameraTransform.y)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector3.up * Time.deltaTime * 2f);
        }
        else
        {
            if (transform.position.y > 5)
            {
                transform.Translate(Vector3.down * Time.deltaTime * 2f);
            }
        }

        if (Input.GetKeyDown(KeyCode.U) && transform.position.y <= 5)
        {
            IsLightOn = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Runner>())
        {
            
            _defaultMoveSpeed = other.gameObject.GetComponent<Runner>().moveSpeed;
            IsSlowingRunner = true;
            _runner = other;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Runner>())
        {
            IsSlowingRunner = false;
            _runner.gameObject.GetComponent<Runner>().moveSpeed = _defaultMoveSpeed;
            _runner = null;
            
        }
    }
}
