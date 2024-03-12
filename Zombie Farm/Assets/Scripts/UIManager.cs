using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //==== FIELDS ====
    GameObject gateButton;
    GameObject firingButton;

    [SerializeField] HumanManager humanManager;
    [SerializeField] Wall wall;
    
    //==== START ====
    void Start()
    {
        gateButton = GameObject.Find("GateButton");
        gateButton.GetComponent<Button>().onClick.AddListener(GateButtonMethod);
        firingButton = GameObject.Find("FiringButton");
        firingButton.GetComponent<Button>().onClick.AddListener(FiringButtonMethod);
    }

    //==== UPDATE ====
    void Update()
    {
        
    }

    //==== BUTTON METHODS ====
    void FiringButtonMethod()
    {
        humanManager.Firing = !humanManager.Firing;
        if (humanManager.Firing)
        {
            firingButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Cease Fire!";
        }
        else
        {
            firingButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Open Fire!";
        }
    }
    void GateButtonMethod()
    {
        wall.GateActive = !wall.GateActive;
        if (wall.GateActive)
        {
            gateButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Close the Gate!";
            Instantiate(wall.GatePrefab, wall.transform.position, Quaternion.identity);
        }
        else
        {
            gateButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Open the Gate!";
            Destroy(GameObject.FindGameObjectWithTag("Gate"));
        }
    }
}
