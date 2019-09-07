using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Bird : MonoBehaviour {

	[SerializeField] private float upForce = 100;
	[SerializeField] public bool isDead;
	[SerializeField] private UnityEvent OnJump, OnDead, onAddPoint;
	[SerializeField] private int score;
    [SerializeField] private Text scoreText;
	private Animator animator;

	private Rigidbody2D rigidBody2d;
	// Use this for initialization

	void Start () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead && Input.GetMouseButtonDown(0)) {
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

	public void AddScore(int value)
	{
		score += value;
		if(onAddPoint != null)
		{
			onAddPoint.Invoke();
			scoreText.text = score.ToString();
		}
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
		Debug.Log("is the bird dead ?"+isDead);
   }


}
