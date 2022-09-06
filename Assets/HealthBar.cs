using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maximumVolume;
    [SerializeField] private float _minimunVolume;

    private HealthSlider _healthSlider;
    private float _health;
    private Coroutine _fadeInJob;
    private float _target;

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
            _healthSlider.SetHealth(_health);
            yield return null;
        }
    }
}
