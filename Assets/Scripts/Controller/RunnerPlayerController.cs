using UnityEngine;

namespace Controller
{
    public class RunnerPlayerController : MonoBehaviour
    {
        public float moveSpeed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                transform.position += Vector3.forward * moveSpeed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position += Vector3.left * moveSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * moveSpeed;
            }
        }
    }
}
