using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;

public class web : MonoBehaviour
{
   void Start()
    {
        // A correct website page.
        //StartCoroutine(GetRequest("http://localhost/solidState/GetDate.php"));

        // A non-existing page.
        //StartCoroutine(GetRequest("http://localhost/solidState/GetUsers.php"));
        //StartCoroutine(GetRequest("http://solidstate.42web.io/GetUsers.php"));
        Debug.Log ("Start coroutine");
        StartCoroutine(MakeRequests());
        Debug.Log ("After MakeRequests");
        //StartCoroutine(GetRequest("http://solidstate.42web.io"));
        //StartCoroutine(GetRequest("http://google.com"));
        //StartCoroutine(Login("Test1", "1234"));
        //StartCoroutine(RegisterUser("Test3", "1234", "oelkhatib2014@gmail.com"));

    }

    public IEnumerator GetRequest(string uri)
    {
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //webRequest.SetRequestHeader ("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36 Edg/91.0.864.59 OPR/38.0.2220.41");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        //using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/solidState/Login.php", form))
        using (UnityWebRequest www = UnityWebRequest.Post("http://solidState.42web.io/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "User Login Success")
                    SceneManager.LoadScene("MainMenu");
                if (www.downloadHandler.text == "Admin Login Success")
                    SceneManager.LoadScene("AdminPage");
            }
        }
    }
    public IEnumerator RegisterUser(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        form.AddField("loginEmail", email);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/solidState/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    private IEnumerator MakeRequests() {
        // GET
        //var getRequest = CreateRequest("https://jsonplaceholder.typicode.com/todos/1");
        Debug.Log ("MakeRequests");
        var getRequest = CreateRequest("http://solidstate.42web.io/GetDate.php");
        Debug.Log ("Request Created");
        Debug.Log (getRequest);
        yield return getRequest.SendWebRequest();
        Debug.Log ("result");
        Debug.Log (getRequest.result);
        Debug.Log ("error");
        Debug.Log (getRequest.error);
        Debug.Log ("responseCode");
        Debug.Log (getRequest.responseCode);
        Debug.Log ("uri");
        Debug.Log (getRequest.uri);
        Debug.Log ("url");
        Debug.Log (getRequest.url);
        //Debug.Log (getRequest.GetRequestHeader());
        //Debug.Log (getRequest.GetResponseHeader());
        Debug.Log (getRequest.GetResponseHeaders());
        Dictionary<string, string> p = getRequest.GetResponseHeaders();
        if (p.Count > 0) {
            foreach (KeyValuePair<string, string> kvp in p) {
                Debug.Log(kvp.Key);
                Debug.Log (kvp.Value);
            }
        }
        Debug.Log ("-----------------------------------------------------");
        //var deserializedGetData = JsonUtility.FromJson<Todo>(getRequest.downloadHandler.text);
        Debug.Log ("return: " + getRequest.downloadHandler.text);
        //Debug.Log ("deserializedGetData");        
        //Debug.Log (deserializedGetData);
        /*
        // POST
        var dataToPost = new PostData(){Hero = "John Wick", PowerLevel = 9001};
        var postRequest = CreateRequest("https://reqbin.com/echo/post/json", RequestType.POST, dataToPost);
        yield return postRequest.SendWebRequest();
        var deserializedPostData = JsonUtility.FromJson<PostResult>(postRequest.downloadHandler.text);
        */
        // Trigger continuation of game flow
    }
    private UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null) {
        var request = new UnityWebRequest(path, type.ToString());

        if (data != null) {
            var bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("User-Agent", " ");

        return request;
    }

    private void AttachHeader(UnityWebRequest request,string key,string value)
    {
        request.SetRequestHeader(key, value);
    }
}

public enum RequestType {
    GET = 0,
    POST = 1,
    PUT = 2
}

public class Todo {
    // Ensure no getters / setters
    // Typecase has to match exactly
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[System.Serializable]
public class PostData {
    public string Hero;
    public int PowerLevel;
}

public class PostResult
{
    public string success { get; set; }
}

