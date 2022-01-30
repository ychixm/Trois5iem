using System;
using UnityEngine;

namespace Controller
{
    public class Runner : MonoBehaviour
    {
        public float moveSpeed;
        public float rotationSpeed;
        public float maxSpeed;
        
        private Rigidbody _rb;

        // debug only
        public GameObject helicopter;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();

            // debug only
            Instantiate(helicopter, new Vector3(10, 15, 0), Quaternion.identity);
        }

        private void Update()
        {
            if (_rb.velocity.magnitude > maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * maxSpeed;
            }
            
            Accelerate();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<Tile3D>())
            {
                Debug.Log("trigger");
            }
        }

        private void Accelerate()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                _rb.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
                Turn();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _rb.AddForce(-transform.forward * moveSpeed, ForceMode.Acceleration);
                Turn();
            }
        }

        private void Turn()
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