using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomGenerator : MonoBehaviour
{
    public string URL = "";
    public Transform roomsParent;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RestClient.Instance.Get(URL, GetRooms));
    }

    void GetRooms(RoomList roomList)
    {
        foreach (Room room in roomList.rooms)
        {
            GameObject go = new GameObject(room.roomName);
            go.transform.SetParent(roomsParent);
            go.transform.localPosition = new Vector3(room.roomX, room.roomY, room.roomZ);
            text.text = text.text + "  " + go.name;
        }
    }
}
