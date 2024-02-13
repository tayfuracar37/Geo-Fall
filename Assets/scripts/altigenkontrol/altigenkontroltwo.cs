using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altigenkontroltwo : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket a��s�
    private float movementSpeed = 6f; // Hareket h�z�

    private void Start()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SixAngle"))
        {


            StartCoroutine(MoveCylinder());

        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("Cube") || other.CompareTag("FiveAngle") || other.CompareTag("Triangle"))
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
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime*2.5f);

            // D�nme
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
