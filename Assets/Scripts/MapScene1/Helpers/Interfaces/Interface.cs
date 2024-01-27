//using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers.Interfaces
{
    public interface IPlayerRagDollCharacterController
    {
        public void ActivateRagDollCharacter();
        public void DeactivateRagDollCharacter();
    }
    
    public interface IPlayerAnimation
    {
        public void MovementAnimation(in Boolean isPlayerMovement);
        public void JumpAnimation(in Boolean isPlayerJump);
        public void SlideAnimation(in Boolean isPlayerSlide);
        public void DanceAnimation(in Boolean isPlayerDance);
        public void DizzyAnimation();
        public void KickAnimation();
        public void VictoryAnimation();
        public void DieAnimation();

        public Animator PlayerCharacterAnimator { get; }
    }
    
    internal interface ILevelController
    {
        public void LevelObjectAnimation();
    }

    internal interface ISoundManager
    {
        public void PlaySoundEffect(String soundName, Boolean isPlay);
    }
}
