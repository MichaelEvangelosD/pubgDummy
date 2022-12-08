using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Login("tsest", "test"));
    }

    IEnumerator Login(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unity/Login.php", form)) {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
