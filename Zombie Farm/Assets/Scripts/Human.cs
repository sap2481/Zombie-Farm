using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    //==== FIELDS ====
    [SerializeField] Bullet bulletPrefab;
    Vector3 position = Vector3.zero;
    bool firing = false;
    float firingCounter;
    float firingSpeed;

    //==== PROPERTIES ====
    public Vector3 Position { get { return position; } set { position = value; } }
    public bool Firing { get { return firing; } set { firing = value; } }
    
    //==== START ====
    void Start()
    {
        position = transform.position;

        firingCounter = 0;
        firingSpeed = 0.5f;
    }

    //==== UPDATE ====
    void Update()
    {
        //Set firing logic
        firingCounter += Time.deltaTime;
        if (firing && firingCounter > firingSpeed && GameObject.FindGameObjectsWithTag("Zombie").Length > 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            firingCounter = 0;
        }
    }
}
