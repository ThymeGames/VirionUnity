using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlopaCollisions : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {

        Buff buff = col.GetComponent<Buff>();
        if (buff != null) {
            if (buff.buff_type == "Dash") {
                bool success = gameObject.GetComponent<Dashing>().IncrementCount();
                if (success) {
                    Destroy(col.gameObject);
                    FindObjectOfType<AudioManager>().Play("Buff");
                }
            }
        }

    }
}
