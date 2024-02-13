using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kupkontrol : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket açýsý
    private float movementSpeed = 4f; // Hareket hýzý

    public int scorethree=1;  

    public bool hascollided = false;
    




    public void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (hascollided)
            return;

        
       if(other.CompareTag("Cube"))
        {
            StartCoroutine(MoveCylinder());
            PatternMove.Instance.IncreaseScore(scorethree);
            hascollided = true;
            
        }
        else if (other.CompareTag("Cylinder") || other.CompareTag("SixAngle") || other.CompareTag("FiveAngle") || other.CompareTag("Triangle"))
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
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime*3);

            // Dönme
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
 
}
