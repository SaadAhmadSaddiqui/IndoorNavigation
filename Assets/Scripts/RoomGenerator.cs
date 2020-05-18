using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Generates rooms on runtime after getting a response from the WebAPI.
/// </summary>
public class RoomGenerator : MonoBehaviour
{
    public string URL = ""; // URL set in the inspector where you get the Json from.
    public Transform roomsParent; // Parent Game Object called "Rooms" to hold all the actual room destinations.
    public Text text; // Panel text just for testing.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RestClient.Instance.Get(URL, GenerateRooms));
    }

    /// <summary>
    /// Receives the rooms list after the Json conversion into a roomslist and then initializes all the rooms under the parent Game Object called "Rooms".
    /// </summary>
    /// <param name="roomList">The room list received from the Json. </param>
    void GenerateRooms(RoomList roomList)
    {
        foreach(Room room in roomList.rooms)
        {
            GameObject go = new GameObject(room.roomName); // Names the rooms.
            go.transform.SetParent(roomsParent); // Sets parents Game Object called "Rooms".
            go.transform.localPosition = new Vector3(room.roomX, room.roomY, room.roomZ); // Sets position under the parent Game Object called "Rooms".
            text.text = text.text + "  " + go.name; // ***Testing purpose only: writes the names of all the rooms generated on a panel.***
        }

        GameObject.Find("Pathdebugger").GetComponent<NavigationController>().FillList(roomsParent); // Fills up the list of destinations in the "Pathdebugger" Game Object immediately after getting all the rooms.
    }
}
