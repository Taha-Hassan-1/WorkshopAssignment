using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : IWeapon
{
    private MonoBehaviour coroutineHandler;

    public Missile(MonoBehaviour handler)
    {
        coroutineHandler = handler;
    }
    public void Shoot(GameObject _missile)
    {
        GameManager.Instance.MissileCount++;
        Debug.Log("Launching a Missile");
        coroutineHandler.StartCoroutine(MoveDown(_missile));
        
    }
    public void GetRandomPostion(GameObject arsenal)
    {
        arsenal.transform.rotation = new Quaternion(180, 0 ,0, 0);
        float randomX = UnityEngine.Random.Range(-6.5f, 6.5f);
        float randomY = UnityEngine.Random.Range(2.8f, 3f);
        arsenal.transform.localPosition = new Vector3(randomX, randomY, 0);

        //return new Vector3(randomX, randomY,0);
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator MoveDown(GameObject _gameObject)
    {
        float speed = 3f;
        if (_gameObject)
        {
            while (_gameObject.transform.position.y > -3f)
            {
                _gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
                yield return null;
            }
            Object.Destroy(_gameObject, 0.2f);
        }

    }
}
