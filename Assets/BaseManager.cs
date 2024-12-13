using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BaseManager : MonoBehaviour
{
    public GameObject[] vie;      // Tableau de vies
    public Volume volum;          // Volume pour l'effet Vignette

    private AudioSource duckHitBaseSound;
    private int nbvie = 0;        // Nombre de vies restantes
    private bool isColliding = false;  // Emp�che plusieurs collisions

    Vignette vignette;
    ChromaticAberration chrom;
    void Start()
    {
        duckHitBaseSound = GetComponent<AudioSource>();
        volum.profile.TryGet(out vignette);
        volum.profile.TryGet(out chrom);
    }

    // D�tecter les collisions entre les GameObjects avec des Colliders attach�s
    void OnCollisionEnter(Collision collision)
    {
        // Si une collision a d�j� eu lieu, ne rien faire
        if (isColliding) return;

        // V�rifier le tag de l'objet avec lequel on entre en collision
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Base hit");

            // Emp�cher les collisions multiples
            isColliding = true;

            // Jouer le son de collision
            duckHitBaseSound.PlayOneShot(duckHitBaseSound.clip);

            // D�truire l'objet ennemi
            Destroy(collision.gameObject);

            // Activer l'effet Vignette (intensit� au maximum)
            vignette.intensity.value = 1.0f;
            chrom.intensity.value += 0.5f;
            // D�truire la vie actuelle
            if (nbvie < vie.Length)
            {
                Destroy(vie[nbvie]);
                nbvie++;
            }

            // Si toutes les vies sont perdues, charger la sc�ne "GameOver"
            if (nbvie >= vie.Length)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    // R�activer la d�tection de collision apr�s un d�lai (si n�cessaire)
    IEnumerator ResetCollision()
    {
        // Attendre un court instant avant de r�activer les collisions
        yield return new WaitForSeconds(1f);
        isColliding = false;
    }

    // Update est appel� une fois par frame (non n�cessaire ici)
    void Update()
    {
        // Lancer le reset des collisions (si besoin)
        if (isColliding)
        {
            StartCoroutine(ResetCollision());
        }
    }
}
