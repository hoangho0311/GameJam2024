using Helpers.Tags;
using UnityEngine;

namespace Levels
{
    public class DoorDashWall : MonoBehaviour
    {
        private Rigidbody[] _DoorDashWallRb;
        
        private void Awake()
        {
            _DoorDashWallRb = GetComponentsInChildren<Rigidbody>();
        }

        private void Start()
        {
            SetUpDoorDashWall();
        }

        /// <summary>
        /// Destroy door dash wall components
        /// </summary>
        private void DestroyDoorDashWall()
        {
            foreach (var doorDashWallRb in _DoorDashWallRb)
            {
                doorDashWallRb.isKinematic = false;
            }
        }

        /// <summary>
        /// SetUp door dash wall components
        /// </summary>
        private void SetUpDoorDashWall()
        {
            foreach (var doorDashWallRb in _DoorDashWallRb)
            {
                doorDashWallRb.isKinematic = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" || other.tag == "Bot")
            {
                DestroyDoorDashWall();
            }
        }
    }
}