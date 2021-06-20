using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombPickUp : MonoBehaviour
{
	public AudioClip pickupClip;

	private Animator anim;
	private bool landed = false;

	void Awake()
	{
		anim = transform.root.GetComponent<Animator>();
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);
			other.GetComponent<LayBombs>().bombCount++;
			GameObject.Find("BombsCount").GetComponent<Text>().text = "Bombs:" + other.GetComponent<LayBombs>().bombCount;//ui计数
			Destroy(transform.root.gameObject);
		}
		else if (other.tag == "Ground" && !landed)
		{
			anim.SetTrigger("Land");
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;
		}
	}
}