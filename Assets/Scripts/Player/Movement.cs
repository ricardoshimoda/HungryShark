using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    static private Movement _S;
    static public Movement S {
        get {
            return _S;
        }
        private set {
            if (_S != null) {
                Debug.LogWarning("Second attempt to set Movement singleton _S");
            }
            _S= value;
        }
    }

    [Tooltip("Constant speed for the shark")]
    public float speed = 10;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.ClampMagnitude(new Vector3(x, y, 0), 1.0f);
        _rb.velocity = movement * speed;
    }
}
