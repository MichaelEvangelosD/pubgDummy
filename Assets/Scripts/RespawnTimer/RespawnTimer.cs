using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTimer : MonoBehaviour
{
    [SerializeField]float health = 100f;
    [SerializeField]public Vector3 offScreenPos;
    [SerializeField]public Vector3 respawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Respawning...");
        StartCoroutine(Respawn());
        Debug.Log("Respawned");
    }

    public IEnumerator Respawn()
    {
        transform.position = offScreenPos;
        yield return new WaitForSeconds(5);
        transform.position = respawnPoint;
        health = 100f;
    }
}
