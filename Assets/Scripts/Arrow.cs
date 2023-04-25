using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] float arrowSpeed = 5f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * arrowSpeed;
    }

    void Update()
    {
        FlipSprite();
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);

        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
    
    void FlipSprite()
    {
        bool arrowHasHorizontalSpeed = Mathf.Abs(xSpeed) > Mathf.Epsilon;
        if(arrowHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(xSpeed), 1f);
        }    
    }
}
