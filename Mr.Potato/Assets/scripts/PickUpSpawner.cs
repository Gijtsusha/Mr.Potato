using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float intervalTime = 5f;
    public float leftX = 12f;
    public float rightX = -12f;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        StartCoroutine(spawnPickUp());
    }

    public IEnumerator spawnPickUp()
    {
        yield return new WaitForSeconds(intervalTime);

        float randomx = Random.Range(leftX, rightX);
        Vector3 randomPos = new Vector3(randomx, 15, 0);

        if (playerHealth.health <= 25)
        {
            Instantiate(pickups[0], randomPos, Quaternion.identity);
        }
        else if(playerHealth.health >= 75)
        {
            Instantiate(pickups[1], randomPos, Quaternion.identity);
        }
        else
        {
            int index = Random.Range(0, pickups.Length);
            Instantiate(pickups[index], randomPos, Quaternion.identity);
        }
    }
}
