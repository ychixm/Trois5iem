using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class Runner : MonoBehaviour
    {
        public float moveSpeed;
        public float rotationSpeed;
        public float maxSpeed;

        public GameObject cameraHolder;
        
        private Rigidbody _rb;
        private RaycastHit Hit;

        private float actualRow;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            bool isGrounded = Physics.Raycast(transform.position, -transform.up, out Hit, 0.02f);

            if (isGrounded && !Hit.collider.isTrigger)
            {
                _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation;
            }

            if (Hit.collider != null)
            {
                Debug.Log(Hit.collider.gameObject.GetComponentInParent<Tile3D>().row);
                actualRow = Hit.collider.gameObject.GetComponentInParent<Tile3D>().row;

                float centerOfMap = (Hit.collider.gameObject.GetComponentInParent<Tile3D>().map3D.size - 1) / 2;
                
                Debug.Log("actual row " + actualRow);
                Debug.Log("size de la map après calcul " + centerOfMap);
                Debug.Log("calcul " + Math.Abs(centerOfMap - actualRow));
                
                if (Math.Abs(centerOfMap - actualRow) < 0.1)
                {
                    Hit.collider.gameObject.GetComponentInParent<Tile3D>().map3D.map.Scroll(Direction.NORTH);
                    transform.position = new Vector3(transform.position.x + 10, transform.position.y,
                        transform.position.z);
                }
            }

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
                
            }
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if(other.collider.name == "P_PoliceCar")
            {
                SceneManager.LoadSceneAsync("policeMiniGame");
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
                cameraHolder.transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0f,rotationSpeed,0f));
                cameraHolder.transform.Rotate(new Vector3(0f, -rotationSpeed, 0f));
            }
        }
    }
}