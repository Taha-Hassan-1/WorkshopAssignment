using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject Bullet; 
    public GameObject Grenade; 
    public GameObject Missile;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            InstantiateWeapon("bullet");
        }
        else if (Input.GetKey(KeyCode.G))
        {
            InstantiateWeapon("grenade");
        }
        else if (Input.GetKey(KeyCode.M))
        {
            InstantiateWeapon("missile");
        }
        //else
        //    Debug.LogError("Wrong Key Pressed.");
    }
    public void InstantiateWeapon(string weaponType)
    {
        WeaponFactory weaponFactory = new WeaponFactory();
        IWeapon weapon = weaponFactory.CreateWeapon(weaponType);
        GameObject weaponObject = Instantiate(GetWeaponPrefab(weaponType), transform.position, Quaternion.identity);
        weapon.Shoot(weaponObject);
    }
    private GameObject GetWeaponPrefab(string weaponType)
    {
        switch (weaponType.ToLower())
        {
            case "bullet":
                return Bullet;
            case "grenade":
                return Grenade;
            case "missile":
                return Missile;
            default:
                {
                    Debug.Log("Prefab not Found");
                    return null;
                }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
