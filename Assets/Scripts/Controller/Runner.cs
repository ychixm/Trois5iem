using System;
using UnityEngine;

namespace Controller
{
    public class Runner : MonoBehaviour
    {
        public float moveSpeed;

        private Rigidbody _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                _rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                _rb.AddForce(Vector3.left * moveSpeed, ForceMode.Acceleration);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _rb.AddForce(Vector3.right * moveSpeed, ForceMode.Acceleration);
            }
        }
    }
}
