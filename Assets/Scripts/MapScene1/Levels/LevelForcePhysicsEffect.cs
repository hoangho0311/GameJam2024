using System;
using System.Collections;
using System.Collections.Generic;
using Helpers.Tags;
using UnityEngine;

namespace Levels
{
    public class LevelForcePhysicsEffect : MonoBehaviour
    {
        private Rigidbody _RigidBody;

        private Rigidbody _LevelRb => _RigidBody;
        
        // Start is called before the first frame update
        private void Start()
        {
            _RigidBody = GetComponent<Rigidbody>();
            
            SetUpLevelForcePhysics();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set up level force physics with Rigidbody
        /// </summary>
        private void SetUpLevelForcePhysics()
        {
            _LevelRb.isKinematic = true;
        }
    }
}
