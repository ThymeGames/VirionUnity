using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtRadius : MonoBehaviour
{

    public GameObject prefab;
    public float radius = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        float phi = Random.value * 2 * Mathf.PI;
        float x = radius * Mathf.Cos(phi);
        float y = radius * Mathf.Sin(phi);

        Vector3 pos = new Vector3(x, y);

        Instantiate(
            prefab,
            pos,
            Quaternion.identity
        );
    }

}
