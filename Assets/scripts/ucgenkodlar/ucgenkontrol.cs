using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ucgenkontrol : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket a��s�
    private float movementSpeed = 4f; // Hareket h�z�

    public int scorefive=1;
    private bool hasCollided = false;

    

    private void Start()
    {

    }

    public  void OnTriggerEnter(Collider other)
    {
        if (hasCollided) // E�er zaten bir kere temas etmi�se
            return;
      
       if (other.CompareTag("Triangle"))
        {
            StartCoroutine(MoveCylinder());
            PatternMove.Instance.IncreaseScore(scorefive);
            hasCollided = true;

        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("Cube") || other.CompareTag("FiveAngle") || other.CompareTag("SixAngle"))
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
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime*3);

            
           transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

           elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
   
}
