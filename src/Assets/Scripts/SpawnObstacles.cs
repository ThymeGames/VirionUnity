using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

    public Transform ParentOfProteins;
    public float probaSpawn = 0.01f;
    public float cooldownMin = 1f, cooldownStart = 2f, cooldownDropSpeed = 1 / 30;
    public float destroyTimer = 5f;

    public float velocityMin = 0.01f, velocityMax = 0.03f;
    public float ymax = 1, ymin = -1;
    public float ystep = 0.18f;
    public float acceleration = 1f;

    float cooldown;
    float timer = 0;
    float timerPersistent = 0;

    public List<GameObject> prefabs = new List<GameObject>();

    void Awake() {
        cooldown = cooldownStart;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in ParentOfProteins) {
            Debug.Log("Add " + t.gameObject.name);
            prefabs.Add(t.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if ((Random.value < probaSpawn) && (timer > cooldown)) {
            Spawn();
            timer = 0;
        }

        cooldown = cooldownMin + cooldownStart * Mathf.Exp(-cooldownDropSpeed * timerPersistent);

        // Debug.Log(cooldown);

        timer += Time.deltaTime;
        timerPersistent += Time.deltaTime;

    }

    void Spawn() {
        int i = Random.Range(0, prefabs.Count - 1);

        GameObject obj = Instantiate(prefabs[i], transform.position, Quaternion.identity);
        Bounds bounds = obj.GetComponent<SpriteRenderer>().bounds;

        float yspace = ymax - ymin - bounds.size.y;
        float y = Random.value * yspace;
        y = Mathf.Round(y / ystep) * ystep;

        Vector2 position = new Vector2(
            transform.position.x,
            ymin + bounds.extents.y + y
        );

        obj.transform.position = position;
        
        // obj.transform.Rotate(Vector3.forward * Random.Range(0, 4) * 90);

        float velocity = velocityMin + (velocityMax - velocityMin) * Random.value;
        ObstacleMovement mov = obj.AddComponent<ObstacleMovement>();
        mov.velocity = velocity;
        mov.acceleration = acceleration;

        obj.AddComponent<BoxCollider2D>();

        Destroy(obj, destroyTimer);
    }

}
