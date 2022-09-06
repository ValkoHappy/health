using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScale : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maximumVolume;
    [SerializeField] private float _minimunVolume;
    [SerializeField] private Slider _slider;

    private float _health;
    private Coroutine _fadeInJob;
    private float _target;

    private void Start()
    {
        //_fadeInJob = StartCoroutine(FadeIn());
    }

    public void OnButtonClickPlus()
    {
        if (_fadeInJob != null)
        {
            StopCoroutine(_fadeInJob);
        }
        _fadeInJob = StartCoroutine(FadeIn());
        _target = _maximumVolume;
    }

    public void OnButtonClickMinus()
    {
        if (_fadeInJob != null)
        {
            StopCoroutine(_fadeInJob);
        }
        _fadeInJob = StartCoroutine(FadeIn());
        _target = _minimunVolume;
    }

    private IEnumerator FadeIn()
    {
        while (_health != _target)
        {
            OnButtonClickPlus();
            OnButtonClickMinus();
            _health = Mathf.MoveTowards(_health, _target, _speed * Time.deltaTime);
            _slider.value = _health;
            yield return null;
        }
    }

    //[SerializeField] private Slider _slider;
    //[SerializeField] private float _number;
    //[SerializeField] private float _maximumHealth;

    //private float _health;

    //private void Start()
    //{
    //    _health = _maximumHealth;
    //    _slider.value = _health;
    //}
    //private void Update()
    //{
    //    OnButtonClickPlus();
    //    OnButtonClickMinus();
    //}

    //public void OnButtonClickPlus()
    //{
    //    _health += _number;
    //    _slider.value = _health;
    //}

    //public void OnButtonClickMinus()
    //{
    //    _health -= _number;
    //    _slider.value = _health;
    //}
}
