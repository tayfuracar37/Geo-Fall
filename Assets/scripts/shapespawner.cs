using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapespawner : MonoBehaviour
{
    public GameObject[] models; // gerekli olan modeller i�in bir dizi olu�turdum
    public int olusturulacakmodelsayisi = 2; // olusturulacak model say�s�n� belirledim
    public float ikimodelarasimesafe = 5; // iki model aras� dikey uzakl�k belirlendi

    public GameObject[] icindengecenobjeler; // kal�plar�n i�inden ge�en modeller
    public float icindengecehiz = 10f; // y ekseni boyunca verdi�im h�z

    private int currentModelIndex = 0;
    private GameObject currentModel;

    public GameObject spawnnoktasiobjesi;

    public float genelharekethizi;

    public GameObject kamera;

    Vector3 spawnnoktasi;
    public float initialSpeed = 0.0f; // Ba�lang�� h�z�
    public float ivme = 0.1f; // Ivme miktar�

    private float currentSpeed;
    Vector3 deneme;

    public GameObject shape;
    public GameObject[] childobject;
    Vector3 shapepos;




    void Start()
    {
        foreach (GameObject obj in childobject)
        {
            obj.transform.parent = shape.transform;
        }

        //currentSpeed = initialSpeed;
        Vector3 spawnpos = transform.position; // uzayda bir nokta belirledim 
        


        for (int i = 0; i < olusturulacakmodelsayisi; i++)
        {
            int randomindex = Random.Range(0, models.Length); //rastgele bir index numaras� atad�m

            GameObject newmodels = Instantiate(models[randomindex], spawnpos, Quaternion.Euler(90, 0, 0));// yeni pozisyon i�in oyun objesi tan�mlad�m ve modelleri kopyalay�p posiyon ve rotasyon verdim

            spawnpos.y -= ikimodelarasimesafe; // dikeyde yeni bir pozisyon g�ncelledim


        }

        // ba�ang�� i�in ilk modeli olu�turdum
        //int randomindextwo = Random.Range(0, icindengecenobjeler.Length);
        //spawnpostwo.y += 2;
        //GameObject newicindengecenobjeler = Instantiate(icindengecenobjeler[randomindextwo], spawnpostwo, Quaternion.Euler(90, 0, 0));

        



    }


    void Update()
    {
        shapepos = shape.transform.position;
        //currentSpeed += ivme * Time.deltaTime;
        //spawnnoktasi = new Vector3(0, 6 - currentSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Destroy(currentModel);
            currentModel = null;

            if (currentModel != null)
            {
                Destroy(currentModel);  // Mevcut modeli yok ettim aq yeter be b�kt�m
            }
            currentModel = Instantiate(icindengecenobjeler[currentModelIndex], shapepos, Quaternion.Euler(90, 0, 0));
        }

            // Yeni bir model olu�tu

            
            currentModelIndex = (currentModelIndex + 1) % models.Length;  // Bir sonraki model

            //deneme = spawnnoktasi;


         

        
        
    }

   

    

   


}






