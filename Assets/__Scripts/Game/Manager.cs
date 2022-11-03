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

    public GameObject goodFish;

    public GameObject badFish;

    public GameObject textScore;

    private int _score = 0;

    public void startGame() {
        Shark.S.alive = true;
        _score = 0;
    }

    public void endGame() {
        Shark.S.alive = false;
    }

    public void incScore() {
        _score++;
        textScore.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + _score;

    }
}
