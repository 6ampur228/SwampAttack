using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangetSpread;

    private Vector2 _positionForShot;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangetSpread, _rangetSpread);
        _positionForShot = new Vector2(Target.transform.position.x / 2, Target.transform.position.y);
    }

    private void Update()
    {
        if (Target != null)
        {
            if (Vector2.Distance(transform.position, _positionForShot) < _transitionRange)
            {
                NeedTransit = true;
            }
        }
        else
        {
            NeedTransit = true;
        }
    }
}
