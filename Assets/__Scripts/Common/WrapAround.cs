using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{

    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other) {
        if (!enabled) {
            return;
        }
        ScreenWrap bounds = other.gameObject.GetComponent<ScreenWrap>();
        if (bounds != null) {
            Vector3 relativeLoc = bounds.transform.InverseTransformPoint(transform.position);
            if (Mathf.Abs(relativeLoc.x) > 0.5f) {
                relativeLoc.x *= -1;
            }
            if (Mathf.Abs(relativeLoc.y) > 0.5f) {
                relativeLoc.y *= -1;
            }
            transform.position = bounds.transform.TransformPoint(relativeLoc);
        }
    }
}
