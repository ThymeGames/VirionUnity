using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    // Start is called before the first frame update

    int count = 3;
    public float dashImpulse = 1f;

    Rigidbody2D rb;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d") && (count > 0)) {
            DoDash();
            Debug.Log("dashes left " + count.ToString());
        }
    }

    void DoDash() {
        rb.AddForce(Vector2.right * dashImpulse, ForceMode2D.Impulse);
        count--;
    }

    public void IncrementCount() {
        count++;
        Debug.Log("count is incremented");
    }
}
