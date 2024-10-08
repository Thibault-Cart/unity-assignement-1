using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scriptSoldier : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public GameObject bullet;
    public GameObject shootpoint;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);


        float mouseY = Input.GetAxis("Mouse Y");
        float newRotationX = cam.transform.localEulerAngles.x - mouseY * rotationSpeed * Time.deltaTime;

        // Convert the angle to the range [-180, 180] to handle clamping correctly.
        if (newRotationX > 180) newRotationX -= 360;

        // Clamp the angle between -20 and 20 degrees.
        newRotationX = Mathf.Clamp(newRotationX, -20f, 20f);

        // Apply the clamped rotation back to the camera.
        cam.transform.localEulerAngles = new Vector3(newRotationX, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);


        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);


        if (Input.GetMouseButton(0))
        {
            GameObject b = Instantiate(bullet) ;
           
            b.transform.position = shootpoint.transform.position;
            b.transform.rotation = shootpoint.transform.rotation;
        }
    }

}

