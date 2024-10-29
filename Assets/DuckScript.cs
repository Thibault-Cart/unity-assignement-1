using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class scriptTest : MonoBehaviour
{
   

    private GameObject objectiv;

    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        objectiv = GameObject.Find("Base");
        agent = GetComponent<NavMeshAgent>();
    }
    
    





    void Update()
    {
        print(objectiv.transform);

        agent.destination=objectiv.transform.position;
       
    }
}
