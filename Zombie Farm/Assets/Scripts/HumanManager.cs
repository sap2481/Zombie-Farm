using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    //==== FIELDS ====
    List<Human> humans = new List<Human>();
    [SerializeField] Human humanPrefab;
    bool firing;

    //==== PROPERTIES ====
    public bool Firing { get { return firing; } set { firing = value; } }
    
    //==== START ====
    void Start()
    {
        firing = false;

        humans.Add(Instantiate(humanPrefab, new Vector3(-3, 3, 0), Quaternion.identity));
        humans.Add(Instantiate(humanPrefab, new Vector3(-3, -3, 0), Quaternion.identity));
    }

    //==== UPDATE ====
    void Update()
    {
        for (int i = 0; i < humans.Count; i++)
        {
            humans[i].Firing = firing;
        }
    }
}
