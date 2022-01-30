using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class Runner : MonoBehaviour
    {
        public float moveSpeed;
        public float rotationSpeed;
        public float maxSpeed;
        
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            RaycastHit Hit;
            bool isGrounded = Physics.Raycast(transform.position, -transform.up, out Hit, 0.02f);

            if (isGrounded && !Hit.collider.isTrigger)
            {
                _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
            
            if (_rb.velocity.magnitude > maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * maxSpeed;
            }
            
            Accelerate();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            if (other.GetComponentInParent<Tile3D>())
            {
                Debug.Log("trigger");
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
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0f,rotationSpeed,0f));
            }
        }
    }
}