using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IWeapon
{
    public void Shoot(GameObject _missile)
    {
        Vector3 _startPosition = new Vector3(0f, -1f, 0f);
        _missile.transform.position = _startPosition;
        Debug.Log("Launching a Missile");
        StartCoroutine(MoveUp(_missile));
        Destroy(_missile, 4f);
    }
    // Update is called once per frame
    void Update()
    {
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
}
