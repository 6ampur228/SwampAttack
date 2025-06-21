using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.left, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        if(collision.gameObject.TryGetComponent(out Destroyer destroyer))
        {
            Destroy(gameObject);
        }
    }
}
