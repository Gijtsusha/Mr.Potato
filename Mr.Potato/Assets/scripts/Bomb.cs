using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float bombRadius = 10f;
	public float bombForce = 100f;
	public AudioClip boom;
	public AudioClip fuse;
	public float fuseTime = 2f;
	public GameObject explosion;


	private LayBombs layBombs;
	private PickUpSpawner pickupSpawner;


	void Awake()
	{
		pickupSpawner = GameObject.Find("pickUpManager").GetComponent<PickUpSpawner>();
		layBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<LayBombs>();
	}

	void Start()
	{
		if (transform.root == transform)
			StartCoroutine(BombDetonation());
	}


	IEnumerator BombDetonation()
	{
		AudioSource.PlayClipAtPoint(fuse, transform.position);
		yield return new WaitForSeconds(fuseTime);
		Explode();
	}


	public void Explode()
	{
		layBombs.bombLaid = false;
		pickupSpawner.StartCoroutine(pickupSpawner.spawnPickUp());
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Enemies"));
		foreach (Collider2D en in enemies)
		{
			Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
			if (rb != null && rb.tag == "Enemy")
			{
				rb.gameObject.GetComponent<Enemy>().HP = 0;
				Vector3 deltaPos = rb.transform.position - transform.position;
				Vector3 force = deltaPos.normalized * bombForce;
				rb.AddForce(force);
			}
		}
		Instantiate(explosion, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(boom, transform.position);
		Destroy(gameObject);
	}
}