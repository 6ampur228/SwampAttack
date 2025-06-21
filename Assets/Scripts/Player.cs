using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] List<Weapon> _weapons;
    [SerializeField] Transform _shootPoint;

    [SerializeField] int _maxHealth;

    private Weapon _currentWeapon;
    private Animator _animator;

    private int _currentHealth;
    private int _currentWeaponNumber = 0;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    public int Money { get; private set; }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void OnMouseDown()
    {
        _currentWeapon.Shot(_shootPoint);
        _animator.Play("Shoot");
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;

        MoneyChanged?.Invoke(Money);

        _weapons.Add(weapon);
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }

    public void SetNextWeapon()
    {
        if(_currentWeaponNumber == _weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void SetPreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
