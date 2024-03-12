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

    //==== PROPERTIES ====
    public bool GateActive { get { return gateActive; } set { gateActive = value; } }
    public GameObject GatePrefab { get { return gatePrefab; } }
    
    //==== START ====
    void Start()
    {
        health = 1000;

        gateActive = false;

        spaceDownThisFrame = false;
        spaceDownLastFrame = false;
    }

    //==== UPDATE ====
    void Update()
    {
        spaceDownThisFrame = Input.GetKeyDown(KeyCode.Space);
        
        /*If Space was just clicked, instantiate the gate
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
        }*/

        spaceDownLastFrame = spaceDownThisFrame;
    }
}
