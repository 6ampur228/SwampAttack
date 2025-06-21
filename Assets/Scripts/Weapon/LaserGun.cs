using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    public override void Shot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
    }
}
