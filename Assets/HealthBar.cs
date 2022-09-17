using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private float _speed;

    private float _maximumVolume;
    private float _minimunVolume;
    private Health _healthPlayer;
    private float _health;
    private Coroutine _fadeInJob;
    private float _target;

    private void Start()
    {
        _health = _healthPlayer.HealthPlayer;
        _maximumVolume = _healthPlayer.MaxHealth;
        _minimunVolume = _healthPlayer.MinHealth;
    }

    public void ChangeHealthBar()
    {
        if(_healthPlayer.HealthPlayer != _health)
        {
            _fadeInJob = StartCoroutine(FadeIn());
            _health = _healthPlayer.HealthPlayer;
        }
        if (_fadeInJob != null)
        {
            StopCoroutine(_fadeInJob);
        }
    }

    private IEnumerator FadeIn()
    {
        while (_health != _target)
        {
            _health = Mathf.MoveTowards(_healthPlayer.HealthPlayer, _target, _speed * Time.deltaTime);
            _healthBarSlider.value = _health;
            yield return null;
        }
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
}
