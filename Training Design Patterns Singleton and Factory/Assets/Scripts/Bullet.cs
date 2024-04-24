using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IWeapon
{
    private MonoBehaviour coroutineHandler;

    public Bullet(MonoBehaviour handler)
    {
        coroutineHandler = handler;
    }
    public void Shoot(GameObject _bullet)
    {
        Debug.Log("Shooting with a Bullet");
        GameManager.Instance.BulletCount++;
        coroutineHandler.StartCoroutine(MoveUp(_bullet));
        
    }
    public void GetRandomPostion(GameObject arsenal)
    {
        float randomX = UnityEngine.Random.Range(-6.5f, 6.5f);
        float randomY = UnityEngine.Random.Range(-3f, 2.9f);
        arsenal.transform.localPosition = new Vector3(randomX, randomY, 0);

        //return new Vector3(randomX, randomY,0);
    }
    IEnumerator MoveUp(GameObject _gameObject)
    {
        float speed = 5f;
        if (_gameObject)
        {
            while (_gameObject.transform.position.y < 3.5f)
            {
                _gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
                yield return null;
            }
            Object.Destroy(_gameObject, 0.2f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
