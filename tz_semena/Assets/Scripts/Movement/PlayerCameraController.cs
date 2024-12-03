using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class PlayerCameraController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform target;

        [Header("Properties")]
        [SerializeField] private Vector3 followOffset;
        [SerializeField] private float followSpeed;

        public void MoveCamera()
        {
            transform.position = Vector3.Lerp(
                transform.position,
                target.position + followOffset,
                followSpeed * Time.deltaTime);
        }
    }
}