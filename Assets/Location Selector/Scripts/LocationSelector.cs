using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using UnityEngine.EventSystems;
=======
>>>>>>> parent of b1b2283... Revert "Location Selector Added - Final Build (Hopefully)"

public class LocationSelector : MonoBehaviour
{
    MeshCollider planeCollider;
    public Vector3 worldPosition;
    public GameObject cube;
    public Text posText;
    Ray ray;

    private Camera cam;
    

    private void Start()
    {
        planeCollider = GetComponent<MeshCollider>();
        cam = Camera.main;

    }

    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (planeCollider.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
        }
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
=======
        if (Input.GetMouseButtonDown(0))
>>>>>>> parent of b1b2283... Revert "Location Selector Added - Final Build (Hopefully)"
        {
            if (GameObject.Find("Cube(Clone)"))
            {
                Destroy(GameObject.Find("Cube(Clone)"));
            }
            Instantiate(cube, worldPosition, Quaternion.identity);
            posText.text = "X Position: " + worldPosition.x + "\nZ Position: " + worldPosition.z; 
        }
    }
<<<<<<< HEAD

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
=======
>>>>>>> parent of b1b2283... Revert "Location Selector Added - Final Build (Hopefully)"
}
