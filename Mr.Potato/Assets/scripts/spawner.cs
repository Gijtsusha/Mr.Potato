using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
	public float spawnTime = 5f;        // 产生敌人的间隔时间
	public float spawnDelay = 3f;       // 产生敌人前的延时
	public GameObject[] enemies;

	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	void Update()
    {
        
    }

	void Spawn()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}
