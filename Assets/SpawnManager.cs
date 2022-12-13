using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject playerPrefab;
    public Transform spawnPointTeam1;
    public Transform spawnPointTeam2;
    [SerializeField] bool isTeam1;
   [SerializeField] bool isTeam2;
    public static SpawnManager instance;
     private IEnumerator coroutine;
    // Update is called once per frame
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;

        }
    }
    private void Start()
    {
        var positionTeam1 = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        var positionTeam2 = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null && isTeam1 == true)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPointTeam1.position + positionTeam1, Quaternion.identity);
                Debug.Log(positionTeam1);
            }
            if (playerPrefab != null && isTeam2 == true)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPointTeam2.position + positionTeam2, Quaternion.identity);
                Debug.Log(positionTeam2);
            }
        }
    }
    public void Respawner()
    {
        var positionTeam1 = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        var positionTeam2 = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null && isTeam1 == true)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPointTeam1.position + positionTeam1, Quaternion.identity);
                Debug.Log(positionTeam1);
            }
            if (playerPrefab != null && isTeam2 == true)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPointTeam2.position + positionTeam2, Quaternion.identity);
                Debug.Log(positionTeam2);
            }
        }
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + "Joined to" + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(PhotonNetwork.NickName + "Joined to" + PhotonNetwork.CurrentRoom.Name + "" + PhotonNetwork.CurrentRoom.PlayerCount);

    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
 public void RespawnPlayers()
    {
        coroutine = RespawnCoroutine(2.0f);
        StartCoroutine(coroutine);

    }
    private IEnumerator RespawnCoroutine(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
}
