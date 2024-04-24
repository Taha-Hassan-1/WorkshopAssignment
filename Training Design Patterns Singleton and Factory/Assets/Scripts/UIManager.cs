using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SpriteRenderer BulletBackground;
    public SpriteRenderer GrenadeBackground;
    public SpriteRenderer MissileBackground;
    public TextMeshProUGUI BulletText;
    public TextMeshProUGUI GrenadeText;
    public TextMeshProUGUI MissileText;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize()
    {
        AddListeners();
    }
    public void AddListeners()
    {
        GameManager.OnBulletSpawn += ChangeUIForBullet;
        GameManager.OnGrenadeSpawn += ChangeUIForGrenade;
        GameManager.OnMissileSpawn += ChangeUIForMissile;
    }
    public void RemoveListeners()
    {
        GameManager.OnBulletSpawn -= ChangeUIForBullet;
        GameManager.OnGrenadeSpawn -= ChangeUIForGrenade;
        GameManager.OnMissileSpawn -= ChangeUIForMissile;
    }
    void ChangeUIForBullet()
    {
        BulletBackground.gameObject.SetActive(true);
        GrenadeBackground.gameObject.SetActive(false);
        MissileBackground.gameObject.SetActive(false);
        BulletText.text = "Bullet Fired: "+ GameManager.Instance.BulletCount.ToString();
        BulletText.gameObject.SetActive(true);
        GrenadeText.gameObject.SetActive(false);
        MissileText.gameObject.SetActive(false);
    }
    void ChangeUIForMissile()
    {
        BulletBackground.gameObject.SetActive(false);
        GrenadeBackground.gameObject.SetActive(false);
        MissileBackground.gameObject.SetActive(true);
        MissileText.text = "Missiles Launched: " + GameManager.Instance.MissileCount.ToString();
        BulletText.gameObject.SetActive(false);
        GrenadeText.gameObject.SetActive(false);
        MissileText.gameObject.SetActive(true);
    }
    void ChangeUIForGrenade()
    {
        BulletBackground.gameObject.SetActive(false);
        GrenadeBackground.gameObject.SetActive(true);
        MissileBackground.gameObject.SetActive(false);
        GrenadeText.text = "Grenades Launched: " + GameManager.Instance.GrenadeCount.ToString();
        BulletText.gameObject.SetActive(false);
        GrenadeText.gameObject.SetActive(true);
        MissileText.gameObject.SetActive(false);
    }
}
