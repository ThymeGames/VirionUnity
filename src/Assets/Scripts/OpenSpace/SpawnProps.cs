using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProps : MonoBehaviour
{

    public GameObject[] pfsProp;
    // public GameObject pfProp;

    public int[] Ns;
    public Transform parent;
    public float width = 5f, height = 5f;
    public float scale = 1f;
    // public int N = 10;

    public int n_trials_max = 5;

    // Start is called before the first frame update
    void Awake()
    {
        int n_prefabs = pfsProp.Length;
        int[] counters = new int[n_prefabs];

        for (int i_prefab = 0; i_prefab < n_prefabs; i_prefab++) {
            counters[i_prefab] = 0;
        }

        bool any_available = true;

        while (any_available) {
            any_available = false;
            for (int i_prefab = 0; i_prefab < n_prefabs; i_prefab++) {
                int N = counters[i_prefab];
                bool is_available = N < Ns[i_prefab];
                if (is_available) {
                    GameObject pfProp = pfsProp[i_prefab];
                    any_available = true;
                    CreateProp(pfProp);
                    counters[i_prefab]++;
                }
            }
        }
    }

    bool CreateProp(GameObject pfProp) {
        for (int i_trial = 0; i_trial < n_trials_max; ++i_trial) {
            GameObject prop = ProposeProp(pfProp);
            if (IsOverlappig(prop)) {
                Destroy(prop);
            } else {
                return true;
            }
        }
        return false;
    }

    GameObject ProposeProp(GameObject pfProp)
    {
        Vector3 position = new Vector3(
            (Random.value - 0.5f) * width,
            (Random.value - 0.5f) * height,
            0
        );

        Quaternion rotation = Quaternion.Euler(
            0.0f,
            0.0f,
            Random.Range(0.0f, 360.0f)
        );

        GameObject prop = Instantiate(
            pfProp,
            position,
            rotation,
            parent
        );

        Vector3 propScale = prop.transform.localScale;
        
        float scaleMagnitude = scale * (1 + (Random.value - 0.5f));
        prop.transform.localScale = propScale * scaleMagnitude;

        return prop;
    } 

    bool IsOverlappig(GameObject prop) {
        foreach (Transform child in parent.transform) {
            if (child == prop.transform) {
                continue;
            }
            Bounds child_bounds = child.GetComponent<SpriteRenderer>().bounds;
            Bounds prop_bounds = prop.GetComponent<SpriteRenderer>().bounds;
            if (child_bounds.Intersects(prop_bounds)) {
                return true;
            }
        }
        return false;
    }

}
