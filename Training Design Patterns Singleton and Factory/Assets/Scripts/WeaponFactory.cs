using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory
{
    public IWeapon CreateWeapon(string weaponType, MonoBehaviour t)
    {
        switch (weaponType.ToLower())
        {
            case "bullet":
                return new Bullet(t);
            case "grenade":
                return new Grenade(t);
            case "missile":
                return new Missile(t);
            default:
                throw new System.ArgumentException("Invalid weapon type");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
