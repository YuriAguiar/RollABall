using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		Speed = 10f;
		count = 0;
		winText.text = "";
		SetCountText();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce(movement * Speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
		}	
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	}
}
