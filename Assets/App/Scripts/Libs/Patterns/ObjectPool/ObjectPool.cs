﻿using System.Collections.Generic;
using App.Scripts.Libs.Patterns.ObjectPool.Scriptable;
using App.Scripts.Libs.Patterns.StateMachine.MonoSystem;
using UnityEngine;

namespace App.Scripts.Libs.Patterns.ObjectPool
{
    public abstract class ObjectPool<TObjectType> : MonoSystem, IObjectPool<TObjectType>
    {
        [SerializeField] protected ObjectPoolDataScriptable scriptable;

        protected readonly Stack<TObjectType> PoolObjects = new();
        
        protected readonly List<TObjectType> UsingObjects = new();
        
        public abstract TObjectType Create();
        
        public abstract TObjectType Get();
        
        
        public abstract void ReturnObject(TObjectType pooledObject);
        
        public abstract void TakeObject(TObjectType pooledObject);
        
        public abstract void DestroyObject(TObjectType pooledObject);
        
        public abstract void Clear(bool clearUsing);
    }
}