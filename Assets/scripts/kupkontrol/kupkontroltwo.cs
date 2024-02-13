using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kupkontroltwo : MonoBehaviour
{
    private float rotationAngle = 25f; // Hareket a��s�
    private float movementSpeed = 10f; // Hareket h�z�

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            StartCoroutine(MoveCylinder());


        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("SixAngle") || other.CompareTag("FiveAngle") || other.CompareTag("Triangle"))
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
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime*3);

            // D�nme
            transform.Rotate(Vector3.down, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
