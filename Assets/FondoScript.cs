using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoScript : MonoBehaviour
{
    public GameObject asteroids;
    float next_spawn_time;

    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time = Time.time + 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            Instantiate(asteroids, new Vector3(Random.Range(-10, 10), 10.0f, 0), Quaternion.identity);
            next_spawn_time += 1.0f;
        }
    }
}
