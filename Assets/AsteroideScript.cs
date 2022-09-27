using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideScript : MonoBehaviour
{
    Vector2 velocity;
    int hp = 3;

    int collisions, puntos = 0;
    public Sprite sprite1;
    public Sprite sprite2;

    // Start is called before the first frame update
    void Start()
    {
        velocity.y = -0.05f;
        collisions = 0;
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "disparo")
        {
            switch (collisions)
            {
                case 0:
                    //GetComponent<SpriteRenderer>().sprite = sprite1;
                    collisions++;
                    break;
                case 1:
                    //GetComponent<SpriteRenderer>().sprite = sprite2;
                    collisions++;
                    break;
                case 2:
                    puntos++;
                    Destroy(gameObject);
                    break;
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
