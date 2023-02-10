using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;

    public event System.Action OnPlayerDeath;

    float screanHalfWidth;
    void Start()
    {
        screanHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + transform.localScale.x/2;     
    }
    private void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * movementSpeed;

        transform.Translate(Vector3.right * velocity * Time.fixedDeltaTime);
        
        if(transform.position.x < -screanHalfWidth)
        {
            transform.position = new Vector2(screanHalfWidth, transform.position.y);
        }
        if (transform.position.x > screanHalfWidth)
        {
            transform.position = new Vector2(-screanHalfWidth, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallingCube")
        {
            if(OnPlayerDeath!= null)
            {
                OnPlayerDeath(); 
            }
            Destroy(gameObject);
        }
    }
}
