﻿using System.Text;
using App.Scripts.Libs.EntryPoint.MonoInstaller;
using App.Scripts.Libs.Patterns.Service.Container;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Base.Scriptable;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Basic.Int
{
    public class AnimatedIntView : MonoInstaller
    {
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private string prefix;
        [SerializeField] private string postfix;

        [SerializeField] private AnimationOptionsScriptable scriptable;

        private StringBuilder _builder;
        private int _value;

        public override void Init(ServiceContainer container)
        {
            _builder = new(prefix);
            _builder.Append(0);
            _builder.Append(postfix);
        }
        
        public void SetValue(int value)
        {
            _builder.Replace(_value.ToString(), value.ToString());
            label.text = _builder.ToString();
            _value = value;
        }
        
        public void SetValueAnimated(int value)
        {
            DOTween.To(GetValue, SetValue, value, scriptable.animationTime)
                .SetEase(scriptable.showEase)
                .SetLink(gameObject);
        }
        
        
        private int GetValue() => _value;
    }
}