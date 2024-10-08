using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Vitesse de déplacement
    public float moveSpeed = 5f;

    // Vitesse de rotation (sur l'axe Z)
    public float rotationSpeed = 100f;

    public string DuckName="Donald";

    void Update()
    {

       
        // Déplacement vers l'avant et l'arrière avec les flèches haut et bas
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }

        // Rotation gauche et droite sur l'axe Z avec les flèches gauche et droite
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}
