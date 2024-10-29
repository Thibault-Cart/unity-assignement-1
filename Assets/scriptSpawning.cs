using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSpawning : MonoBehaviour
{
    public float spawntime = 10.0f;
    private float timesinceLastSpawn = 0;
    public float SpawnRange = 100;
    public GameObject duck;
    // Start is called before the first frame update
    void Start()
    {
        timesinceLastSpawn =spawntime;
        spawnDuck();
    }

    // Update is called once per frame
    void Update()
    {
        timesinceLastSpawn -= Time.deltaTime;

        if (timesinceLastSpawn <= 0.0f)
        {

            spawnDuck();
            timesinceLastSpawn = spawntime;
        }
    }

    void spawnDuck()
    {
        GameObject b = Instantiate(duck);

        // Générer un décalage aléatoire entre -200 et 200 sur les axes X et Z
        float randomX = Random.Range(-SpawnRange, SpawnRange);
        float randomZ = Random.Range(-SpawnRange, SpawnRange);
        Vector3 offset = new Vector3(randomX, 0, randomZ);

        // Générer une rotation aléatoire sur l'axe Z
        float randomRotationZ = Random.Range(0f, 360f);

        // Positionner le GameObject à la position actuelle avec le décalage aléatoire
        b.transform.position = this.transform.position + offset;

        // Appliquer une rotation aléatoire sur l'axe Z tout en gardant les rotations sur X et Y
        b.transform.rotation = Quaternion.Euler(b.transform.rotation.eulerAngles.x, b.transform.rotation.eulerAngles.y, randomRotationZ);

    }
}
