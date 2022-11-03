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
                Debug.LogWarning("Second attempt to set Movement singleton _S");
            }
            _S= value;
        }
    }

    [Tooltip("Constant speed for the shark")]
    public float speed = 10;

    public bool alive = true;

    public GameObject score;

    private int _score = 0;

    private Rigidbody2D _rb;

    void Start()
    {
        _score = 0;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (alive) {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 movement = Vector3.ClampMagnitude(new Vector3(x, y, 0), 1.0f);
            _rb.velocity = movement * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "BadFish") {
            _rb.velocity = Vector3.zero;
            alive = false;
        } else {
            _score++;
            score.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + _score;
            Destroy(other.gameObject);
        }

    }
}
