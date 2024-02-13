using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SilindirKontrol : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket açýsý
    private float movementSpeed = 8f; // Hareket hýzý

    public int scorefour=1;  // private score variable

    public bool hasCollided;

    public static SilindirKontrol SilindirKontrolone;

    public void Awake()
    {
        SilindirKontrolone = this;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (hasCollided) // Eðer zaten bir kere temas etmiþse
            return;

   
       if(other.CompareTag("Cylinder"))
        {
            StartCoroutine(MoveCylinder());
            PatternMove.Instance.IncreaseScore(scorefour);
            hasCollided = true;
           
        }
        else if (other.CompareTag("SixAngle") || other.CompareTag("Cube") || other.CompareTag("FiveAngle") || other.CompareTag("Triangle"))
        {

            PatternMove.Instance.restartfactor = true;
        }
    }

    private System.Collections.IEnumerator MoveCylinder()
    {
        
        float elapsedTime = 0f;
        float duration = 0.5f; // Hareketin süresi

        while (elapsedTime < duration)
        {
            // Hareket
            transform.Translate(Vector3.right*-1 * movementSpeed * Time.deltaTime);

            // Dönme
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    


}
