using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppearenceNPC : MonoBehaviour
{

    public float time_start = 1f;
    public float proba = 1e-2f;

    public int nRows = 2;
    public int nCols = 2;
    public Vector2 step;

    public Transform ParentOfProteins;

    Vector2 origin;
    public List<GameObject> prefabs = new List<GameObject>();

    SpriteRenderer sr;
    Vector2Int indexHide = new Vector2Int(0, 0);
    GameObject[,] gridObjects;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform t in ParentOfProteins) {
            Debug.Log("Add " + t.gameObject.name);
            prefabs.Add(t.gameObject);
        }

        gridObjects = new GameObject[nRows, nCols];
    }

    GameObject GetRandomPrefab() {
        return prefabs[Random.Range(0, prefabs.Count)];
    }

    void Start() {
        RandomSpawn();
        SwithObject(gridObjects[indexHide.x, indexHide.y]);
    }

    void RandomSpawn() {
        for (int i = 0; i < nRows; i++) {
            for (int j = 0; j < nCols; j++) {
                GameObject prefab = GetRandomPrefab();
                Bounds bounds = prefab.GetComponent<SpriteRenderer>().bounds;
                Vector3 extents = new Vector3(
                    Mathf.Sign(step.x) * bounds.extents.x,
                    Mathf.Sign(step.y) * bounds.extents.y
                );
                Vector3 shift = new Vector3(step.x * j, step.y * i) + extents;
                Vector3 position_spawn = transform.position + shift;
                GameObject obj = Instantiate(prefab, position_spawn, Quaternion.identity, transform);
                gridObjects[i, j] = obj;
            }
        }
    }

    void Update()
    {

        if (Random.value < proba) {

            GameObject obj = gridObjects[indexHide.x, indexHide.y];
            SwithObject(obj);

            Vector2 indexCurrent = indexHide;
            NextRandomIndex();

            GameObject objNext = gridObjects[indexHide.x, indexHide.y];
            SwithObject(objNext);

        }

    }

    void SwithObject(GameObject obj) {
        bool isFadingOut = obj.GetComponent<Fading>().isFadingOut;
        obj.GetComponent<Fading>().isFadingOut = !isFadingOut;
    }

    void NextRandomIndex() {
        if (Random.value > 0.5) {  // X

            if (indexHide.x == 0) {
                indexHide.x++;
            } else if (indexHide.x == nRows - 1) {
                indexHide.x--;
            } else {
                if (Random.value > 0.5) {
                    indexHide.x++;
                } else {
                    indexHide.x--;
                }
            }

        } else { // Y

            if (indexHide.y == 0) {
                indexHide.y++;
            } else if (indexHide.y == nCols - 1) {
                indexHide.y--;
            } else {
                if (Random.value > 0.5) {
                    indexHide.y++;
                } else {
                    indexHide.y--;
                }
            }

        }

    }

}
