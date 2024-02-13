using UnityEngine;

public class SilindirKontrolthree : MonoBehaviour
{
    private float rotationAngle = 20f; // Hareket a��s�
    private float movementSpeed = 8f; // Hareket h�z�

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Cylinder"))
        {
            StartCoroutine(MoveCylinder());
        }
        else if (other.CompareTag("SixAngle") || other.CompareTag("Cube") || other.CompareTag("FiveAngle") || other.CompareTag("Triangle"))
        {

            //e�er totolscore 10 dan kalan 0 ise if(PatternMove.Instance.Totalscore>10){ StartCoroutine(MoveCylinder()) };
           
        }
    }

    private System.Collections.IEnumerator MoveCylinder()
    {
        
        float elapsedTime = 0f;
        float duration = 0.5f; // Hareketin s�resi

        while (elapsedTime < duration)
        {
            // Hareket
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

            // D�nme
            transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
