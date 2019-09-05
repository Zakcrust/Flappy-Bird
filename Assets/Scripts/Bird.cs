using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour {

	[SerializeField] private float upForce = 100;
	[SerializeField] private bool isDead;
	[SerializeField] private UnityEvent OnJump, OnDead;

	private Rigidbody2D rigidBody2d;
	// Use this for initialization
	void Start () {
		rigidBody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead && Input.GetMouseButtonDown (0)) {
		
			Jump ();
		}

	}


	private bool IsDead() {
		return isDead;
	}

	public void Dead()
	{
		//Pengecekan jika belum mati dan value OnDead tidak sama dengan Null
		if (!isDead && OnDead != null)
		{
			//Memanggil semua event pada OnDead
			OnDead.Invoke();
		}

		//Mengeset variable Dead menjadi True
		isDead = true;

	}   

	void Jump(){
	
		if (rigidBody2d) {
		
			rigidBody2d.velocity = Vector2.zero;

			rigidBody2d.AddForce (new Vector2 (0, upForce));
		}

		if (OnJump != null) {

			OnJump.Invoke ();
		}
	}
}
