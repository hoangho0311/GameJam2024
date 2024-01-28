using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Helpers.Interfaces;
using UnityEngine;
using Random = System.Random;

namespace Levels
{
    public class LevelController : MonoBehaviour, ILevelController
    {
        [Header("Types Of Animation")] 
        [Tooltip("Rotate Object Animation")] [SerializeField] private bool _rotateAnimation;
        [Tooltip("Door Animation")] [SerializeField] private bool _doorAnimation;
        [Tooltip("Drone Animation")] [SerializeField] private bool _droneAnimation;
        [Tooltip("Rotator Up Animation")] [SerializeField] private bool _rotatorUpAnimation;
        
        [Header("Animation Speed")]
        [Tooltip("Speed Of Rotate Animation")] [SerializeField] private float _rotate = 2f;
        [Tooltip("Speed Of Rotator Up Animation")][SerializeField] private float _rotatorUp = 2f;
        [Tooltip("Speed Of Position Animation")] [SerializeField] private float _position = 2f;

        // Start is called before the first frame update
        private void Start()
        { 
            LevelObjectAnimation();
        }

        // Update is called once per frame
        private void Update()
        {
            
        }

        /// <summary>
        /// Level object animation controller
        /// </summary>
        public void LevelObjectAnimation()
        {
            if (_rotateAnimation)
            {
                gameObject.transform.DORotate(new Vector3(0f, 360f, 0f), _rotate * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
            }

            if (_doorAnimation)
            {
                gameObject.transform.DOMoveY(transform.position.y + 2.5f, _position * 1.0f, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Flash);
            }

            if (_rotatorUpAnimation)
            {
                gameObject.transform.DORotate(new Vector3(0f, 360f, 0f), _rotatorUp * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
            }

            if (_droneAnimation)
            {
                gameObject.transform.DOMoveY(transform.position.y + 1.0f, _position * 1.0f, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Flash);
            }
        }
    }
}
