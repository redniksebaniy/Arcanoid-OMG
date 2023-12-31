﻿using App.Scripts.Game.LevelManager.DifficultyIncreaser;
using App.Scripts.Libs.Patterns.ObjectPool;
using App.Scripts.Libs.Patterns.Service.Container;

namespace App.Scripts.Game.GameObjects.Ball.Pool
{
    public class BallPool : ObjectPool<Ball>
    {
        private DifficultyIncreaser increaser;

        private bool isBoostState;
        
        public override void UpdateWithDT(float dt)
        {
            foreach (var system in UsingObjects)
            {
                system.UpdateWithDT(dt);
            }
        }

        public override void Init(ServiceContainer container)
        {
            increaser = container.GetService<DifficultyIncreaser>();
            base.Init(container);
        }

        public override void TakeObject(Ball pooledObject, int id = 0)
        {
            base.TakeObject(pooledObject, id);
            pooledObject.SetBoostView(isBoostState);
            pooledObject.SetSpeed(increaser.Speed);
        }

        protected override void PauseSystem()
        {
            foreach (var system in UsingObjects) system.IsPaused = true;
        }
        
        protected override void ResumeSystem()
        {
            foreach (var system in UsingObjects) system.IsPaused = false;
        }
        
        public void ReturnAll()
        {
            while (UsingObjects.Count > 0)
            {
                var ball = UsingObjects[0];
                ReturnObject(ball);
            }
        }

        public void SetSpeed(float newSpeed)
        {
            foreach (var ball in UsingObjects)
            {
                ball.SetSpeed(newSpeed);
            }
        }

        public void SetBoostView(bool state)
        {
            isBoostState = state;
            foreach (var ball in UsingObjects)
            {
                ball.SetBoostView(state);
            }
        }
    }
}