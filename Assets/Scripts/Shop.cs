using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _weaponViewTemplate;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for(int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var weaponView = Instantiate(_weaponViewTemplate, _itemContainer.transform);

        weaponView.BuyButtonClicked += OnBuyButtonClicked;
        weaponView.Render(weapon);
    }

    private void OnBuyButtonClicked(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if(weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);

            weapon.Buy();
            weaponView.BuyButtonClicked -= OnBuyButtonClicked;
        }
    }
}
