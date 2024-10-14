using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scriptTest : MonoBehaviour
{
    public float speed = 0.2f;
    public float lifeTime = 20;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    





    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0.0f)
        {

            Destroy(gameObject);
        }

        this.transform.Translate(0, -speed * Time.deltaTime, 0);

    }
}
