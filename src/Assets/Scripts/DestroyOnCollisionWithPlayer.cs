using UnityEngine;

public class DestroyOnCollisionWithPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
