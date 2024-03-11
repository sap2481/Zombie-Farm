using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    //==== FIELDS ====
    float speed;
    float health;

    Vector3 position = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    //==== PROPERTIES ====
    public float Health { get { return health; } set { health = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public Vector3 Position { get { return position; } set { position = value; } }
    
    //==== START ====
    void Start()
    {
        position = transform.position;
        speed = 3;
        health = 100;
    }

    //==== UPDATE ====
    void Update()
    {
        //Make sure they can move!
        velocity = new Vector3(-(speed * Time.deltaTime), 0, 0);
        position += velocity;
        transform.position = position;
    }
}
