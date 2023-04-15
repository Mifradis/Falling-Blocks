using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 7;
    float screenWidthWithWorldUnits;
    
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenWidthWithWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        if(transform.position.x > screenWidthWithWorldUnits)
        {
            transform.position = new Vector2(-screenWidthWithWorldUnits, transform.position.y);
        }
        if(transform.position.x < -screenWidthWithWorldUnits)
        {
            transform.position = new Vector2(screenWidthWithWorldUnits, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "Falling Block")
        {
            FindObjectOfType<GameOver>().OnGameOver();
            Destroy(gameObject);
        }
    }
}
