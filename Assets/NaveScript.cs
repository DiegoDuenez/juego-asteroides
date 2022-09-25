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
            velocity.x = -0.2f; //afecta la fuerza de empuje
            // position_current.x -= 5; // * afecta los pixeles
         
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            velocity.x = 0.2f;
            // position_current.x += 5;
            
        }
        // transform.position = position_current;
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) velocity.x = 0;

        // Crear Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            float angulo = Mathf.Round(transform.rotation.eulerAngles.z);

            if (angulo >= 0 && angulo <= 90)
            {
                float num1 = (angulo * 100) / 90;

                //Eje de y
                float num2 = (num1 * 1) / 100;

                //Eje de x
                float num3 = 1 - num2;

                PlayerPrefs.SetFloat("num2", num2);
                PlayerPrefs.SetFloat("num3", num3);
            }

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Angulo: " + transform.rotation.eulerAngles.z);
        }

    }

    private void FixedUpdate()
    {
        
        GetComponent<Rigidbody2D>().position += velocity; //Componente que sirve para empujar
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
