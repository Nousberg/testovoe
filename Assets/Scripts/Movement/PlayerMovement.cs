using DG.Tweening.Core;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float moveSpeed;

        private Rigidbody rb => GetComponent<Rigidbody>();

        public void MovePlayer()
        {
            Vector3 keyInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (keyInput.sqrMagnitude > 0f)
            {
                Vector3 moveDirection = keyInput.normalized;

                Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                Vector3 moveVector = moveDirection * moveSpeed;
                moveVector.y = rb.velocity.y;
                rb.velocity = moveVector;
            }
            else
                rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0f, rb.velocity.y, 0f), moveSpeed * Time.deltaTime);
        }
    }
}