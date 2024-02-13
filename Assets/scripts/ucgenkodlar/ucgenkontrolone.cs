using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ucgenkontrolone : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket açýsý
    private float movementSpeed = 4f; // Hareket hýzý

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Triangle"))
        {
            StartCoroutine(MoveCylinder());
            
            

        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("Cube") || other.CompareTag("FiveAngle") || other.CompareTag("SixAngle"))
        {
           
        }
    }

    private System.Collections.IEnumerator MoveCylinder()
    {

        float elapsedTime = 0f;
        float duration = 0.5f; // Hareketin süresi

        while (elapsedTime < duration)
        {
            // Hareket
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime*3);

            // Dönme
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
