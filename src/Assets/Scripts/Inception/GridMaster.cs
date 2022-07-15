using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaster : MonoBehaviour
{

    public float cellSize = 0.18f;
    // public GameObject[] proteins;
    public List<GameObject> proteins = new List<GameObject>();

    Vector2 origin;
    int nRows = 6;
    int nCols = 7;
    bool[,] isOccupied; 

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        isOccupied = new bool[nRows, nCols];
        RefreshOccupation();
    }

    public bool IsSolved() {

        int j = 3;  // middle column
        for (int i = 0; i < nRows; ++i) {
            if (isOccupied[i, j]) {
                return false;
            }
        }

        return true;
    }

    void RefreshOccupation()
    {

        for (int i = 0; i < nRows; ++i) {
            for (int j = 0; j < nCols; ++j) {
                isOccupied[i, j] = false;
            }
        }

        foreach (GameObject p in proteins) {
            Protein p_comp = p.GetComponent<Protein>();

            for (int i = 0; i < nRows; ++i) {
                for (int j = 0; j < nCols; ++j) {

                    float x = origin.x + cellSize * j;
                    float y = origin.y + cellSize * i;

                    Vector3 point = new Vector3(x, y);

                    if (p_comp.bounds().Contains(point)) {
                        string msg = i.ToString() + ", " + j.ToString() + " is occupied by " + p.name;
                        // Debug.Log(msg);

                        isOccupied[i, j] = true;

                    }

                }
            }

        }

        PrintOccupation();
    }

    void PrintOccupation() {
        string line = "\n";
        for (int i = nRows - 1; i >= 0; --i) {
            for (int j = 0; j < nCols; ++j) {
                string s = isOccupied[i, j] ? "+" : "-";
                line += s + " ";
            }
            line += "\n";
        }
        Debug.Log("Occupation: " + line);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject p = FindMouse();

        if (p == null) {
            return;
        }

        MoveProtein(p);

    }

    GameObject FindMouse()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            Debug.Log("Mouse clicked on:");
            Vector2 point = ray.origin;
            Vector2Int indices = FindPointIndices(point);
            Debug.Log(point.ToString() + " " + indices.ToString());
            // Debug.Log("Occupation = " + isOccupied[indices.x, indices.y]);

            if( Physics.Raycast( ray, out hit, 10 ) )
            {
                GameObject t = hit.transform.gameObject;
                FindObjectOfType<AudioManager>().Play("prot_moving");
                Debug.Log(t.name);

                if (!proteins.Contains(t)) {
                    Debug.Log("but no such item in proteins");
                    return null;
                }

                Bounds bounds = t.GetComponent<SpriteRenderer>().bounds;

                Debug.Log("Bounds");
                Debug.Log(bounds.min.ToString() + " " + bounds.max.ToString());

                return t;
                
            } else {
                Debug.Log("nothing");
                return null;
            }
        }

        return null;
    }


    void MoveProtein(GameObject p) {

        bool isVertical = p.GetComponent<Protein>().isVertical();

        if (isVertical) {
            Debug.Log("MoveProteinVertical");
            MoveProteinVertical(p);
        } else {
            Debug.Log("MoveProteinHorizontal");
            MoveProteinHorizontal(p);
        }

        RefreshOccupation();

    }

    Vector2Int FindPointIndices(Vector2 point) {
        int j = (int) (  (point.x - origin.x) / cellSize  );
        int i = (int) (  (point.y - origin.y) / cellSize  );
        return new Vector2Int(i, j);
    }

    Vector2Int[] FindProteinRange(GameObject p, float margin = 0.15f) {

        /*  
        *   .      . top
        *   .      . .
        *   bottom . .
        */

        Vector2 top, bottom;

        Bounds bounds = p.GetComponent<Protein>().bounds();

        if (p.GetComponent<Protein>().isVertical()) {

            top = new Vector2(
                bounds.center.x,
                bounds.min.y + bounds.size.y * (1 - margin)
            );

            bottom = new Vector2(
                bounds.center.x,
                bounds.min.y + bounds.size.y * margin
            );

        } else {

            top = new Vector2(
                bounds.min.x + bounds.size.x * (1 - margin),               
                bounds.center.y
            );

            bottom = new Vector2(
                bounds.min.x + bounds.size.x * margin,               
                bounds.center.y
            );

        }

        Vector2Int indices_top = FindPointIndices(top);
        Vector2Int indices_bottom = FindPointIndices(bottom);

        Vector2Int[] result = new Vector2Int[2];
        result[0] = indices_bottom;
        result[1] = indices_top;

        return result;

    }

    void MoveProteinVertical(GameObject p) {
        Vector2Int[] indices = FindProteinRange(p);
        Vector2Int indices_bottom = indices[0];
        Vector2Int indices_top = indices[1];

        // Debug.Log(indices_bottom.ToString() + " " + indices_top.ToString());

        bool goDown = canGoDown(indices_bottom);
        bool goUp = canGoUp(indices_top);

        if (goDown) {
            while (goDown) {
                p.transform.Translate(Vector3.down * cellSize);
                indices_bottom.x -= 1;
                goDown = canGoDown(indices_bottom);
            }

        } else if (goUp) {
            while (goUp) {
                p.transform.Translate(Vector3.up * cellSize);
                indices_top.x += 1;
                goUp = canGoUp(indices_top);
            }
        }

    }

    void MoveProteinHorizontal(GameObject p) {
        Vector2Int[] indices = FindProteinRange(p);
        Vector2Int indices_bottom = indices[0];
        Vector2Int indices_top = indices[1];

        // Debug.Log(indices_bottom.ToString() + " " + indices_top.ToString());

        bool goLeft = canGoLeft(indices_bottom);
        bool goRight = canGoRight(indices_top);

        if (goLeft) {
            while (goLeft) {
                p.transform.Translate(Vector3.down * cellSize);
                indices_bottom.y -= 1;
                goLeft = canGoLeft(indices_bottom);
            }

        } else if (goRight) {
            while (goRight) {
                p.transform.Translate(Vector3.up * cellSize);
                indices_top.y += 1;
                goRight = canGoRight(indices_top);
            }
        }
    }


    bool canGoDown(Vector2Int indices) {
        bool goDown = (indices.x > 0);
        Debug.Log("Check indices: " + indices.ToString());
        Debug.Log("Is not bottom: " + goDown.ToString());
        if (goDown) {
            goDown &= !isOccupied[indices.x - 1, indices.y];
            Debug.Log("Down is possible: " + goDown.ToString());
        }
        return goDown;
    }


    bool canGoUp(Vector2Int indices)
    {
        bool goUp = (indices.x < nRows - 1);
        Debug.Log("Check indices: " + indices.ToString());
        Debug.Log("Is not top: " + goUp.ToString());
        if (goUp) {
            goUp &= !isOccupied[indices.x + 1, indices.y];
            Debug.Log("Top is possible: " + goUp.ToString());
        }   
        return goUp;
    }

    bool canGoLeft(Vector2Int indices) {
        bool goLeft = (indices.y > 0);
        // Debug.Log(goDown.ToString());
        if (goLeft) {
            goLeft &= !isOccupied[indices.x, indices.y - 1];
            // Debug.Log(goDown.ToString());
        }
        return goLeft;
    }

    bool canGoRight(Vector2Int indices)
    {
        bool goRight = (indices.y < nCols - 1);
        // Debug.Log(goUp.ToString());
        if (goRight) {
            goRight &= !isOccupied[indices.x, indices.y + 1];
            // Debug.Log(goUp.ToString());
        }   
        return goRight;
    }


}
