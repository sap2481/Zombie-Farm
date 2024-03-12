using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //==== FIELDS ====
    GameObject target;
    GameObject[] targetList;
    Vector3 targetPos;

    Vector3 position = Vector3.zero;
    Vector3 direction = Vector3.right;
    Vector3 velocity = Vector3.right;

    float speed;
    
    //==== START ====
    void Start()
    {
        position = transform.position;
        speed = 10;
        
        //Find Target (Make Sure It Isn't In the Stronghold)
        targetList = GameObject.FindGameObjectsWithTag("Zombie");
        for (int i = 0; i < targetList.Length; i++)
        {
            if (targetList[i].transform.position.x > -4)
            {
                target = targetList[i];
                targetPos = target.transform.position;
                break;
            }
        }

        //Calculate Direction At Start
        direction = targetPos - transform.position;
        direction.Normalize();
    }

    //==== UPDATE ====
    void Update()
    {
        //Move Towards Target Zombie
        velocity = direction * speed * Time.deltaTime;
        position += velocity;
        transform.position = position;

        //Despawn If Out of Camera View
        if (position.x > 10 || position.y > 5 || position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
