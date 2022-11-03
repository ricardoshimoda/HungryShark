using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 5;
    public int interval = 4;

    private Vector3 _direction;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("changeDirection", 2, interval);
        _direction = -transform.position;
        setSpeed();
    }

    void Update()
    {
    }

    private void changeDirection() {
        _direction = new Vector3(Random.value, Random.value, 0);
        setSpeed();
    }

    private void setSpeed() {
        _direction.Normalize();
        _rb.velocity = speed * _direction;
    }

    void OnDestroy(){
        CancelInvoke();
    }
}
