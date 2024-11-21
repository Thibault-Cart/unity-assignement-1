using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseManager : MonoBehaviour
{
    private AudioSource duckHitBaseSound;
    // Start is called before the first frame update
    void Start()
    {
        duckHitBaseSound = GetComponent<AudioSource>();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        
        print(collision.gameObject.tag);
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "enemy")
        {
           
            Debug.Log("Base hit");
            duckHitBaseSound.PlayOneShot(duckHitBaseSound.clip);
            Destroy(collision.gameObject);
         // SceneManager.LoadScene("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
