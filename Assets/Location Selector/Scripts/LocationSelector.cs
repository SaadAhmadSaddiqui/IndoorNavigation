using UnityEngine;
using UnityEngine.UI;

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
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("Cube(Clone)"))
            {
                Destroy(GameObject.Find("Cube(Clone)"));
            }
            Instantiate(cube, worldPosition, Quaternion.identity);
            posText.text = "X Position: " + worldPosition.x + "\nZ Position: " + worldPosition.z; 
        }
    }
}
