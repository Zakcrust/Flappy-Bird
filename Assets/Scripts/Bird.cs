using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour {

	[SerializeField] private float upForce = 100;
	[SerializeField] private bool isDead;
	[SerializeField] private UnityEvent OnJump, OnDead;
	private Animator animator;

	private Rigidbody2D rigidBody2d;
	// Use this for initialization
	void Start () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!IsDead() && Input.GetMouseButtonDown (0)) {
		
			Jump ();
		}

	}

	public bool IsDead() {
		return isDead;
	}

	public void Dead() {
		
		if (!isDead && OnDead != null) {
			
			OnDead.Invoke();
		}

		
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

	private void OnCollisionEnter2D(Collision2D collision) {
        animator.enabled = false;
   }


}
