using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayBombs : MonoBehaviour
{
	[HideInInspector]
	public bool bombLaid = false;
	public int bombCount = 0;
	public AudioClip bombsAway;
	public GameObject bomb;

	void Awake()
	{
		
	}


	void Update()
	{
		if (Input.GetButtonDown("Fire2") && !bombLaid && bombCount > 0)
		{
			bombCount--;
			GameObject.Find("BombsCount").GetComponent<Text>().text = "Bombs:" + bombCount;//ui计数
			bombLaid = true;
			AudioSource.PlayClipAtPoint(bombsAway, transform.position);
			Instantiate(bomb, transform.position, transform.rotation);
		}

	}
}
