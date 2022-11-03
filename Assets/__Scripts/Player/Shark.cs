using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Shark : MonoBehaviour
{
    static private Shark _S;
    static public Shark S {
        get {
            return _S;
        }
        private set {
            if (_S != null) {
                Debug.LogWarning("Second attempt to set Shark singleton _S");
            }
            _S= value;
        }
    }

    [Tooltip("Constant speed for the shark")]
    public float speed = 10;

    public bool alive = true;

    private bool _right = true;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (alive) {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 movement = Vector3.ClampMagnitude(new Vector3(x, y, 0), 1.0f);
            _rb.velocity = movement * speed;
            if (_rb.velocity.x > 0 && !_right || _rb.velocity.x < 0 && _right) {
                float xChange = -2 * transform.GetChild(0).localPosition.x;
                transform.GetChild(0).localPosition += new Vector3 (xChange, 0, 0);
                _right = !_right;
            }
        } else {
            _rb.velocity = Vector3.zero;
        }
    }

}
