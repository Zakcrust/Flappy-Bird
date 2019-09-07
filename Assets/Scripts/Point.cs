using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    // Update is called once per frame
    void Update()
    {
        if(!bird.IsDead())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void setSize(float size)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if(collider != null)
        {
            collider.size = new Vector2(collider.size.x,size);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if(bird && !(bird.IsDead()))
        {
            bird.AddScore(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if(bird)
        {
            bird.setHoleY(transform.position.y);
        }
    }
}
