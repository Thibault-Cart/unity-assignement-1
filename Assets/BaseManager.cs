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
    private bool isColliding = false;  // Empêche plusieurs collisions

    Vignette vignette;
    ChromaticAberration chrom;
    void Start()
    {
        duckHitBaseSound = GetComponent<AudioSource>();
        volum.profile.TryGet(out vignette);
        volum.profile.TryGet(out chrom);
    }

    // Détecter les collisions entre les GameObjects avec des Colliders attachés
    void OnCollisionEnter(Collision collision)
    {
        // Si une collision a déjà eu lieu, ne rien faire
        if (isColliding) return;

        // Vérifier le tag de l'objet avec lequel on entre en collision
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Base hit");

            // Empêcher les collisions multiples
            isColliding = true;

            // Jouer le son de collision
            duckHitBaseSound.PlayOneShot(duckHitBaseSound.clip);

            // Détruire l'objet ennemi
            Destroy(collision.gameObject);

            // Activer l'effet Vignette (intensité au maximum)
            vignette.intensity.value = 1.0f;
            chrom.intensity.value += 0.5f;
            // Détruire la vie actuelle
            if (nbvie < vie.Length)
            {
                Destroy(vie[nbvie]);
                nbvie++;
            }

            // Si toutes les vies sont perdues, charger la scène "GameOver"
            if (nbvie >= vie.Length)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    // Réactiver la détection de collision après un délai (si nécessaire)
    IEnumerator ResetCollision()
    {
        // Attendre un court instant avant de réactiver les collisions
        yield return new WaitForSeconds(1f);
        isColliding = false;
    }

    // Update est appelé une fois par frame (non nécessaire ici)
    void Update()
    {
        // Lancer le reset des collisions (si besoin)
        if (isColliding)
        {
            StartCoroutine(ResetCollision());
        }
    }
}
