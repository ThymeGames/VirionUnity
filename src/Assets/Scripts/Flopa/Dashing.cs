using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    // Start is called before the first frame update

    int count = 1;
    public int count_max = 4;
    public float dashImpulse = 1f;

    Rigidbody2D rb;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && (count > 0)) {
            DoDash();
            FindObjectOfType<AudioManager>().Play("Dash");
            Debug.Log("dashes left " + count.ToString());
        }
    }

    void DoDash() {
        rb.AddForce(Vector2.right * dashImpulse, ForceMode2D.Impulse);
        count--;
    }

    public bool IncrementCount() {
        if (count < 4) {
            count++;
            Debug.Log("count is incremented: " + count.ToString());
            return true;
        } else {
            Debug.Log("Ne lezet uzhe khvatit.");
            return false;
        }
    }

    public int GetCount() {
        return count;
    }
}
