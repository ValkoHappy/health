using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _heal;

    private float _maxHealth = 100;
    private float _minHealth = 0;

    public float HealthPlayer => _health;
    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;

    public void TakeHeal()
    {
        if(_health < _maxHealth && _health >= _minHealth)
        {
            _health += _heal;
        }
    }

    public void TakeDamage()
    {
        if (_health <= _maxHealth && _health > _minHealth)
        {
            _health -= _damage;
        }
    }
}
