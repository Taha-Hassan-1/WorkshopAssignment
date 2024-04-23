using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IWeapon
{
    public void Shoot(GameObject _bullet)
    {
        Vector3 _startPosition = new Vector3(0f, -1f, 0f);
        _bullet.transform.position = _startPosition;
        Debug.Log("Shooting with a Bullet");
        StartCoroutine(MoveUp(_bullet));
        Destroy(_bullet, 2f);
    }
    IEnumerator MoveUp(GameObject _gameObject)
    {
        float speed = 2f; 
        while (_gameObject.transform.position.y < 10f) 
        {
            _gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
