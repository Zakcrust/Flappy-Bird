using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pipe : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private string objectTag = "pipe";
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!bird.IsDead())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if(bird)
        {
            Collider2D collider = GetComponent<Collider2D>();

            if(collider && bird.getLives() <= 0)
            {
                collider.enabled = false;
            }
            else
            {
                if(transform.rotation.eulerAngles.z == 180)
                {
                    bird.setPipeY(transform.position.y - 1);
                }
                else
                {
                    bird.setPipeY(transform.position.y);
                }
                
            }

            bird.Dead("pipe");

        }
    }
}
