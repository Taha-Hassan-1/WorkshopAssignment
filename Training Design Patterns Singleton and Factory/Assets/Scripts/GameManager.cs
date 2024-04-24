using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject Bullet; 
    public GameObject Grenade; 
    public GameObject Missile;
    public static event Action OnGrenadeSpawn;
    public static event Action OnBulletSpawn;
    public static event Action OnMissileSpawn;
    public int BulletCount = 0;
    public int GrenadeCount = 0;
    public int MissileCount = 0;

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
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Initialize()
    {
        AddListeners();
    }
    public void AddListeners()
    {
        
    }
    public void RemoveListeners()
    {
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            InstantiateWeapon("bullet");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            InstantiateWeapon("grenade");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            InstantiateWeapon("missile");
        }
        //if (Input.GetKey(KeyCode.B))
        //{
        //    InstantiateWeapon("bullet");
        //}
        //else if (Input.GetKey(KeyCode.G))
        //{
        //    InstantiateWeapon("grenade");
        //}
        //else if (Input.GetKey(KeyCode.M))
        //{
        //    InstantiateWeapon("missile");
        //}
        //else
        //    Debug.LogError("Wrong Key Pressed.");
    }
    public void InstantiateWeapon(string weaponType)
    {
        WeaponFactory weaponFactory = new WeaponFactory();
        IWeapon weapon = weaponFactory.CreateWeapon(weaponType, this);
        GameObject weaponObject = Instantiate(GetWeaponPrefab(weaponType), transform.position , Quaternion.identity);
        weapon.GetRandomPostion(weaponObject);
        weapon.Shoot(weaponObject);
    }
    private GameObject GetWeaponPrefab(string weaponType)
    {
        switch (weaponType.ToLower())
        {
            case "bullet":
                OnBulletSpawn.Invoke();
                return Bullet;
            case "grenade":
                OnGrenadeSpawn.Invoke();
                return Grenade;
            case "missile":
                OnMissileSpawn.Invoke();
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
