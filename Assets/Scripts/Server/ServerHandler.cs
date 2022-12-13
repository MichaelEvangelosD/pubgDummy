using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ServerHandler : MonoBehaviour
{
    public void InitiateRegister(string username, string userpass)
    {
       StartCoroutine(Register(username, userpass));
    }

    IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("UserName", username);
        form.AddField("UserPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://sae-projects.eu/GPR/Register.php", form))
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

    public void InitiateLogin(string username, string userpass)
    {
        StartCoroutine(Login(username, userpass));
    }

    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("UserName", username);
        form.AddField("UserPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://sae-projects.eu/GPR/Login.php", form))
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
}
