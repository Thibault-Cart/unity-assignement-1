using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class scriptTest : MonoBehaviour
{
    public float speed = 0.2f;
    public float lifeTime = 20;
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
        /*
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0.0f)
        {

            Destroy(gameObject);
        }

        this.transform.Translate(0, -speed * Time.deltaTime, 0);
        */
    }
}
