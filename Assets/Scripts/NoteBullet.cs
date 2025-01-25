using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoteBullet : MonoBehaviour
{
    private Vector3 _initPos;
    private Vector3 _finalPos; 
    public float _speed = 1f;
    private float _progress = 0f;
    public UnityEvent _hitEvent;

    // Méthode pour initialiser les positions
    public void Initialize(Vector3 initPos, Vector3 finalPos)
    {
        _initPos = initPos;
        _finalPos = finalPos;
        transform.position = _initPos;
        _progress = 0f;
    }

    void Update()
    {
        if (_progress < 1f)
        {
            _progress += _speed * Time.deltaTime;
            transform.position = Vector3.Lerp(_initPos, _finalPos, _progress);
            if (_progress >= 1f)
            {
                transform.position = _finalPos;
                hit();
            }
        }
    }

    public void hit(){
        _hitEvent.Invoke();
        Destroy(this.gameObject);
    }
}
