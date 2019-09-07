using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Bird : MonoBehaviour {

	[SerializeField] private float upForce = 100;
	[SerializeField] public bool isDead;
	[SerializeField] private UnityEvent OnJump, OnDead,OnHit, OnAddPoint;
	[SerializeField] private int score;
    [SerializeField] private Text scoreText,livesText;
	[SerializeField] private int Lives = 3;
	private bool freezeBird = false;
	private Animator animator;
	private Vector3 startPosition;
	private float pipeY;
	private Rigidbody2D rigidBody2d;
	// Use this for initialization

	void Start () {
		rigidBody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		startPosition = transform.position;
		setLives(Lives);
	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead && Input.GetMouseButtonDown(0) && !freezeBird) {
			Jump ();
		}

	}

	public void setPipeY(float yPos)
	{
		pipeY = yPos;
	}
	public bool IsDead() {
		return isDead;
	}

	public int getLives()
	{
		return Lives;
	}
	public void Dead(string tag) {
		
		decreaseLive();

		if(Lives>0 && !freezeBird)
		{
			if(tag == "ground")
			{
                Hit();
			}
			else if(tag == "pipe")
			{
				pipeHit();
			}
			return;
		}

		if (!isDead && OnDead != null) {
            OnDead.Invoke();		
		}
		
		isDead = true;

	}   

	private void Hit()
	{
		setPosition(startPosition);
		OnHit.Invoke();
	}

	private void setPosition(Vector3 pos)
	{
		transform.position = pos;
	}

	private void pipeHit()
	{
		OnHit.Invoke();
		setPosition(startPosition);
        transform.position = new Vector3(transform.position.x, pipeY + 0.5f, transform.position.z);
	}

	public void AddScore(int value)
	{
		score += value;
		if(OnAddPoint != null)
		{
			OnAddPoint.Invoke();
			scoreText.text = score.ToString();
		}
	}

	private void setLives(int lives)
	{
		livesText.text = "Lives : "+ lives.ToString();
	}

	private void decreaseLive()
	{
		Lives--;
		setLives(Lives);
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
