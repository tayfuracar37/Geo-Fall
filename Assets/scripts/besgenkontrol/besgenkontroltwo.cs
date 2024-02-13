using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class besgenkontroltwo : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket a��s�
    private float movementSpeed = 4f; // Hareket h�z�

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("FiveAngle"))
        {
            StartCoroutine(MoveCylinder());


        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("Cube") || other.CompareTag("SixAngle") || other.CompareTag("Triangle"))
        {
            
        }
    }

    private System.Collections.IEnumerator MoveCylinder()
    {

        float elapsedTime = 0f;
        float duration = 0.5f; // Hareketin s�resi

        while (elapsedTime < duration)
        {
            // Hareket
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime*5);

            // D�nme
            transform.Rotate(Vector3.down, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
