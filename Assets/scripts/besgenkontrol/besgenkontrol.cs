using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class besgenkontrol : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket a��s�
    private float movementSpeed = 4f; // Hareket h�z�

    public int scoretwo = 1;  // private score variable
    private bool hasCollided = false;


    private void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (hasCollided)
            return;

        if (other.CompareTag("FiveAngle"))
        {
            StartCoroutine(MoveCylinder());
            PatternMove.Instance.IncreaseScore(scoretwo);
            hasCollided = true;
        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("Cube") || other.CompareTag("SixAngle") || other.CompareTag("Triangle"))
        {


            PatternMove.Instance.restartfactor = true;

        }
    }

    private System.Collections.IEnumerator MoveCylinder()
    {

        float elapsedTime = 0f;
        float duration = 0.5f; // Hareketin s�resi

        while (elapsedTime < duration)
        {
            // Hareket
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime * 5);

            // D�nme
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);

    }
}
