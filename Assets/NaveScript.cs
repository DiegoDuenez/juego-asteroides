using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{
    int hp = 5;
    public GameObject spawn_tiro;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position_current = transform.position;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            velocity.x = -0.2f; 
         
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            velocity.x = 0.2f;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) velocity.x = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            float angulo = Mathf.Round(transform.rotation.eulerAngles.z);
            float x = 0, y = 0;

            if (angulo >= 0 && angulo <= 90)
            {
                float num1 = (angulo * 100) / 90;
                x = (num1 * -1) / 100;
                y = 1 + x;

            }
            else if (angulo <= 180)
            {
                angulo = angulo - 90;
                float num1 = (angulo * 100) / 90;
                y = (num1 * -1) / 100;
                x = -1 - y;
            }
            else if (angulo <= 270)
            {

                angulo = angulo - 180;
                float num1 = (angulo * 100) / 90;
                x = (num1 * 1) / 100;
                y = -1 + x;

            }
            else if (angulo < 360)
            {
                angulo = angulo - 270;
                float num1 = (angulo * 100) / 90;
                y = (num1 * 1) / 100;
                x = 1 - y;

            }

            PlayerPrefs.SetFloat("num2", x);
            PlayerPrefs.SetFloat("num3", y);


            GameObject tiro = Instantiate(spawn_tiro,
                 transform.position, transform.rotation);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        { 
            transform.Rotate(Vector3.back);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Rotate(Vector3.forward);
        }
       

    }

    private void FixedUpdate()
    {
        
        GetComponent<Rigidbody2D>().position += velocity; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroide")
        {
            Destroy(collision.gameObject);
            hp--;
        }
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }

}
