using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    float min_speed = 5f;
    float max_speed = 30f;
    float rotation_speed = 100f;

    Vector3 angles;

    void Start()
    {
        angles = transform.eulerAngles;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Camera.main.transform.position += transform.forward * speed * Time.deltaTime;
        //hold
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = max_speed;
        }
        //release
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            speed = min_speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angles.y -= rotation_speed * Time.deltaTime;
            angles.y = Mathf.Clamp(angles.y, -30, 30);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            angles.y += rotation_speed * Time.deltaTime;
            angles.y = Mathf.Clamp(angles.y, -30, 30);
        }

        transform.rotation = Quaternion.Euler(angles);
    }
}
