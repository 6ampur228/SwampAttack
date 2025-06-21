using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Sprite _icon;

    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBought = false;

    [SerializeField] protected GameObject Bullet;

    public Sprite Icon => _icon;
    public string Label => _label;
    public int Price => _price;
    public bool IsBought => _isBought;

    public abstract void Shot(Transform shootPoint);

    public void Buy()
    {
        _isBought = true;
    }
}
