using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static private Manager _M;
    static public Manager M {
        get {
            return _M;
        }
        private set {
            if (_M != null) {
                Debug.LogWarning("Second attempt to set Game Manager singleton _M");
            }
            _M= value;
        }
    }

    static private Transform _fishAnchor;
    static Transform fishAnchor {
        get {
            if (_fishAnchor == null) {
                GameObject go = new GameObject("FishAnchor");
                _fishAnchor = go.transform;
            }
            return _fishAnchor;
        }
    }

    public int spawnInterval = 3;

    public GameObject player;

    public GameObject goodFish;

    public GameObject badFish;

    public GameObject textScore;

    public Transform spawnLocationRoot;

    private float _chances = 1f;

    private int _score = 0;

    private bool _alive = true;

    private void Start() {
        _score = 0;
        InvokeRepeating("spawnFish", 0, spawnInterval);
    }

    public void incScore() {
        _score++;
        if (_chances > 0.2f) {
            _chances = _chances - 0.05f;
        }
        textScore.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + _score;
    }

    public void endGame() {
        _alive = false;
        player.GetComponent<Shark>().alive = false;
        CancelInvoke();
    }

    private void spawnFish() {
        if (_alive) {
            Transform location = spawnLocationRoot.GetChild(Random.Range(0, spawnLocationRoot.childCount));
            GameObject fish;
            if (Random.value < _chances) {
                fish = Instantiate(goodFish, location);
            } else {
                fish = Instantiate(badFish, location);
            }
            fish.transform.SetParent(fishAnchor);
        }
    }
}
