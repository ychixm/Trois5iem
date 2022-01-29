using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using UnityEngine;

public class CrossingItem3D : MonoBehaviour
{

    private Vector3 _initialPosition;
    private Vector3 _finalposition;
    private bool _move;

    private void Start()
    {
        _initialPosition = transform.position;
        //transform.Rotate(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            if (Mathf.Abs(transform.position.x - _finalposition.x) >= 0.01f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 2);
            }
            
            else
            {
                
                if (Mathf.Abs(transform.position.x - _initialPosition.x) >= 0.01f)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * 2);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Runner>())
        {
            //transform.Rotate(0,180,0);
            _initialPosition = transform.position;
            _finalposition = _initialPosition;
            _finalposition.x = _initialPosition.x-4;
            _move = true;
        }
    }
}
