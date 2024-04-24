using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : IWeapon
{
    private MonoBehaviour coroutineHandler;

    public Grenade(MonoBehaviour handler)
    {
        coroutineHandler = handler;
    }
    public void Shoot(GameObject _grenade)
    {
        Debug.Log("Throwing a Grenade");
        GameManager.Instance.GrenadeCount++;
        coroutineHandler.StartCoroutine(MoveUp(_grenade));
        
    }
    public void GetRandomPostion(GameObject arsenal)
    {
        float randomX = UnityEngine.Random.Range(-6.5f, 6.5f);
        float randomY = UnityEngine.Random.Range(-3f, 3f);
        arsenal.transform.localPosition = new Vector3(randomX, randomY, 0);

        //return new Vector3(randomX, randomY,0);
    }
    IEnumerator MoveUp(GameObject _gameObject)
    {
        float speed = 2f;
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
