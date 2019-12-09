using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    void Start()
    {
        //Debug or Test functions with database

        //StartCoroutine(GetDate());
        //StartCoroutine(GetUsers());
        //StartCoroutine(Login("testuser2", "qwert"));
        //StartCoroutine(RegisterUser("testuser3", "12345" ));
    }

    //Access GetDate.php file in xampp -> htdocs -> UnityBackend
    IEnumerator GetDate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://joshuafrancisco.servegame.com/Unitybackend/GetDate.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    //Access GetUsers.php file in xampp -> htdocs -> UnityBackend
    public IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://joshuafrancisco.servegame.com/Unitybackend/GetUsers.php"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    //Access Login.php file in xampp -> htdocs -> UnityBackend
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://joshuafrancisco.servegame.com/Unitybackend/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    //Access RegisterUser.php file in xampp -> htdocs -> UnityBackend
    public IEnumerator RegisterUser(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        form.AddField("email", email);

        using (UnityWebRequest www = UnityWebRequest.Post("http://joshuafrancisco.servegame.com/Unitybackend/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}