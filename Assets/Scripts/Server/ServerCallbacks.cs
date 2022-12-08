using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

[DefaultExecutionOrder(0)]
public class ServerCallbacks : MonoBehaviour
{
    public static ServerCallbacks _s;
    public ServerCallbacks GetManager { get => _s; }

    CancellationTokenSource cts;

    private void Awake()
    {
        if (_s != null)
        {
            Destroy(gameObject);
        }
        else { _s = this; }

        cts = new CancellationTokenSource();
    }

    public bool Login(string username, string password)
    {
        Task<bool> task1 = Task<bool>.Factory.StartNew(() =>
        {
            WWWForm form = new WWWForm();
            form.AddField("loginUser", username);
            form.AddField("loginPass", password);

            using (UnityWebRequest www = UnityWebRequest.Post("INSERT_PHP_FILE_HERE", form))
            {
                while(!www.SendWebRequest().isDone)
                {
                    Task.Yield();
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                    return false;
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    return true;
                }
            }
        });

        return task1.Result;
    }
}
