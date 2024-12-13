using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BaseManager : MonoBehaviour
{
    public Volume volum;

    private AudioSource duckHitBaseSound;
    Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        duckHitBaseSound = GetComponent<AudioSource>();
        volum.profile.TryGet(out vignette);
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
            vignette.intensity.value = 1.0f;

            // SceneManager.LoadScene("GameOver");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
