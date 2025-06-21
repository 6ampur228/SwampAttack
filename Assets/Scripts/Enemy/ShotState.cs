using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotState : State
{
    [SerializeField] private Arrow _arrowTemplate;
    [SerializeField] private Transform _startArrowPosition;

    [SerializeField] private float _delay;

    private Animator _animator;

    private float _lastShotTime = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastShotTime <= 0)
        {
            Shot();

            _lastShotTime = _delay;
        }

        _lastShotTime -= Time.deltaTime;
    }

    private void Shot()
    {
        _animator.Play("Shot");

        Instantiate(_arrowTemplate, _startArrowPosition.position, Quaternion.identity); 
    }
}
