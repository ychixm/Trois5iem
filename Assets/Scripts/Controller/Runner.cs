using System;
using System.Collections;
using UnityEngine;

namespace Controller
{
    public class Runner : MonoBehaviour
    {
        public float moveSpeed;
        public float rotationSpeed;

        private Rigidbody _rb;

        public GameObject Helicopter;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();

            Instantiate(Helicopter, new Vector3(0, 15, 0), Quaternion.identity);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                _rb.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
            }

            if (/*_rb.velocity.magnitude > 2*/true)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    transform.Rotate(new Vector3(0f,-rotationSpeed,0f));
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(new Vector3(0f,rotationSpeed,0f));
                }
            }
        }
    }
}
