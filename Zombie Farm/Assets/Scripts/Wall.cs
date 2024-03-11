using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wall : MonoBehaviour
{
    //==== FIELDS ====
    float health;
    [SerializeField] GameObject gatePrefab;
    bool gateActive;

    bool spaceDownLastFrame;
    bool spaceDownThisFrame;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 1000;

        gateActive = false;

        spaceDownThisFrame = false;
        spaceDownLastFrame = false;
    }

    // Update is called once per frame
    void Update()
    {
        spaceDownThisFrame = Input.GetKeyDown(KeyCode.Space);
        
        //If Space was just clicked, instantiate the gate
        if (spaceDownThisFrame && spaceDownLastFrame == false)
        {
            if (!gateActive)
            {
                Instantiate(gatePrefab, transform.position, Quaternion.identity);
                gateActive = true;
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Gate"));
                gateActive = false;
            }
        }

        spaceDownLastFrame = spaceDownThisFrame;
    }
}
