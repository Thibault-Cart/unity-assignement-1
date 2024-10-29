using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletForward : MonoBehaviour
{

    // Reference to the particle system prefab
    public GameObject hitParticlePrefab;

    public float speed = 20;

    public float lifeTime = 10.01f;     //How many seconds(or fraction thereof) this object will survive
    private bool timeToDie = false;    //The object's trigger of its inevitable DEATH!!!
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {

            // Instantiate the particle system at the collision point
            GameObject particleInstance = Instantiate(hitParticlePrefab, collision.contacts[0].point, Quaternion.identity);


            Destroy(collision.gameObject);

        }

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0.0f)
        {
            timeToDie = true;
        }

        if (timeToDie == true)
        {
            Destroy(gameObject);
        }
    }
}
