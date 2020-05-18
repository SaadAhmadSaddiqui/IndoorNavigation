using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestClient : MonoBehaviour
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
    /// <param name="URL"></param>
    /// <returns></returns>
    public IEnumerator Get(string URL, System.Action<RoomList> callBack)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                if (request.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);
                    jsonResult = "{\"rooms\":" + jsonResult + "}";
                    RoomList roomsList = JsonUtility.FromJson<RoomList>(jsonResult);
                    callBack(roomsList);
                }
            }
        }

    }
}
