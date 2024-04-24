using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    void Shoot(GameObject _gameObject);
    void GetRandomPostion(GameObject arsenal);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
