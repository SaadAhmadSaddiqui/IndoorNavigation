using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestClient : MonoBehaviour // Singleton
{
    private static RestClient _instance;

    /// <summary>
    /// Singleton implementation. This is an instance of the object.
    /// </summary>
    public static RestClient Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = typeof(RestClient).Name;
                _instance = go.AddComponent<RestClient>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    /// <summary>
    /// Gets the names and locations for the Rooms in JSON from the database.
    /// </summary>
    /// <param name="URL">The URL to get the rooms list in JSON from.</param>
    /// <param name="callBack">An Action delegate for the RoomGenerator.GenerateRooms(RoomList roomList)</param>
    /// <returns></returns>
    public IEnumerator Get(string URL, System.Action<RoomList> callBack)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest(); // Sends GET request to the Web API to grab the rooms list.

            if (request.isNetworkError)
            {
                Debug.LogError(request.error); // In case of an error, log the error.
            }
            else
            {
                if (request.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data); // Gets the Json form of the rooms list.
                    jsonResult = "{\"rooms\":" + jsonResult + "}"; // Fixing Json for unity.
                    RoomList roomsList = JsonUtility.FromJson<RoomList>(jsonResult); // Extracts rooms list from JSON.
                    callBack(roomsList); // Calls RoomGenerator.GenerateRooms(RoomList roomList)
                }
            }
        }

    }
}
