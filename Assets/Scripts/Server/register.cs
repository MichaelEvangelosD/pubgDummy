using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class register : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Register("test2", "test2"));
    }

    IEnumerator Register(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("registerUser", username);
        form.AddField("registerPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unity/Register.php", form)) {
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
