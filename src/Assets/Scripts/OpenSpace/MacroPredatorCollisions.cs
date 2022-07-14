using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacroPredatorCollisions : MonoBehaviour
{

    public GameObject darkness;
    public float load_menu_offset = 5f;
    public float darkness_offset = 1.5f;

    Animator anim;
    float timer = 0;
    float timer_scene = 100000f;
    float timer_darkness = 1000000f;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timer_scene) {
            LoadMenu();
        }

        if (timer > timer_darkness) {
            // Debug.Log("Instantiate DARKNESS!!!11");
            Instantiate(darkness);
            timer_darkness += 100000f;
        }

        // Debug.Log(timer.ToString());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Player") {

            // Debug.Log("OnCollisionEnter2D  " + tag);

            Vector3 pos = col.gameObject.transform.position;
            transform.position = pos;

            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

            rb.isKinematic = true;
            rb.angularVelocity *= 0;
            rb.velocity *= 0;

            gameObject.GetComponent<Homing>().enabled = false;
            // gameObject.GetComponent<MacroPredatorCollisions>().enabled = false;

            gameObject.GetComponent<Rigidbody2D>().velocity *= 0f;
            anim.Play("Run", -1, 0f);

            timer_scene = timer + load_menu_offset;
            timer_darkness = timer + darkness_offset;

            // Debug.Log(timer_scene.ToString() + " " + timer_darkness.ToString());

        }
    }

    void LoadMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
