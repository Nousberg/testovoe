using Assets.Scripts.Movement;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UpdateManager : MonoBehaviour
    {
        [SerializeField] private PlayerCameraController camController;
        [SerializeField] private PlayerMovement playerMove;

        private void Update()
        {
            playerMove.MovePlayer();
            camController.MoveCamera();
        }
    }
}