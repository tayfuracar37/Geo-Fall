using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PatternMove : MonoBehaviour
{
    public GameObject[] Pattern;
    public float patternSpeed = 2.3f;
    //public float patternDistance=2;
    //public float currentdistance=0;
    public int PatternPiece = 10000;
    private List<GameObject> instantiatedObjectsList = new List<GameObject>();
    public int Totalscore = 0;
    public TextMeshProUGUI scoretext;
    public AudioSource ses;
    public float newspeed;


    private bool isColliderDisabled = false;


    public static PatternMove Instance;
    public float ivme = 0.07f; // hýzýn ivme deðeri


    private float startDelay = 1f;
    private float countdownTime = 3f;
    private float timer = 0.0001f;


    public Button playbutton;


    public bool restartfactor = false;

    public GameObject RestartUI;
    public Button restartbutton;
    public bool baslayabilir = false;
    public TextMeshProUGUI ScoreUItext;

    public TextMeshProUGUI HighScoreText;
    public int HighScore;

    private const string HighScoreKey = "";



    private bool isRestartUIActive = false;

    private float initialPatternDistance = -6f;
    private float fixedDistance = 1f;
    private float ilkmesafe = 2f;

  
    private float olusturulmasuresi = 0.8f;

    public Button soundsactive;
    
    public GameObject music;
    public Button soundsdeactive;
    public TextMeshProUGUI TextMeshProSCORE;

   



    private void Awake()
    {
        Instance = this;

    }


    public void Start()
    {
        soundsdeactive.gameObject.SetActive(false);
        instanitate();
        StartCoroutine(StartCountdown());
        restartbutton.onClick.AddListener(RestartScene);
        soundsactive.onClick.AddListener(soundsactiveMethodON);

        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateHighScoreUI();

    }
    public void StartGameWithCountdown()
    {

        StartCoroutine(StartCountdown());
        StartCoroutine(StartPatternInstantiate());

        playbutton.gameObject.SetActive(false);

    }
    IEnumerator StartPatternInstantiate()
    {
        float currentPatternDistance = initialPatternDistance;

        for (int i = 0; i < PatternPiece; i++)
        {
            if (isRestartUIActive)
                yield break;

            int randomIndex = Random.Range(0, Pattern.Length);
            GameObject instantiatedObject = Instantiate(Pattern[randomIndex], new Vector3(0, currentPatternDistance, 0), Quaternion.identity);
            instantiatedObjectsList.Add(instantiatedObject);

            currentPatternDistance -= fixedDistance;

            yield return new WaitForSeconds(olusturulmasuresi);
        }

        yield return new WaitForSeconds(10f);

        // Clear the list
        instantiatedObjectsList.Clear();
    }


    void Update()
    {

        restart();
        if (timer < startDelay)
        {
            timer += Time.deltaTime;
        }
        else if (!playbutton.isActiveAndEnabled)
        {
            MovePatternObjects();

            if (Totalscore < 100)
            {
                // patternSpeed += ivme * Time.deltaTime;
                if (Totalscore % 1 == 0 && !isColliderDisabled)
                {
                    StartCoroutine(DisableCollidersForDuration(0.5f));
                    isColliderDisabled = true;
                }
            }


        }


        

        if (Totalscore < 40)
        {
            
            
            olusturulmasuresi = 0.7f;

            
        }
        else if (Totalscore >= 50 && Totalscore < 100)//100
        {
            patternSpeed = 2.5f;
            olusturulmasuresi = 0.7f;
        }
      
        else if (Totalscore >= 100)
        {
            patternSpeed = 2.8f;
            olusturulmasuresi = 0.6f;
        }
        else if (Totalscore >=130)
        {
            patternSpeed = 3.1f;
            olusturulmasuresi = 0.25f;
        }
        else if (Totalscore >= 170)
        {
            patternSpeed = 3.4f;
            olusturulmasuresi = 0.24f;
        }
        else if (Totalscore >= 200)
        {
            patternSpeed = 3.7f;
            olusturulmasuresi = 0.2f;
        }
        else if (Totalscore >= 120)
        {
            patternSpeed = 4f;
            olusturulmasuresi = 0.12f;
        }
        else if (Totalscore >= 160)
        {
            patternSpeed = 4.2f;
            olusturulmasuresi = 0.09f;
        }
        else if(Totalscore>=200)
        {
            patternSpeed = 4.5f;
            olusturulmasuresi = 0.07f;
        }
       



    }

    IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;

        }


    }


    public void instanitate()
    {

        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, Pattern.Length);
            GameObject instantiatedObject = Instantiate(Pattern[randomIndex], new Vector3(0, ilkmesafe, 0), Quaternion.identity);
            instantiatedObjectsList.Add(instantiatedObject);
            ilkmesafe -= 2.58f;
        }
    }


    public void IncreaseScore(int score)
    {
        Totalscore += score;
        ScoreUItext.text = "" + Totalscore;
        TextMeshProSCORE.text = "" + Totalscore;

        if (Totalscore > HighScore)
        {

            HighScore = Totalscore;
            PlayerPrefs.SetInt(HighScoreKey, HighScore);
            UpdateHighScoreUI();
        }

        ses.Play();
    }



    private void UpdateHighScoreUI()
    {
        HighScoreText.text = HighScore.ToString();
    }

    public void MovePatternObjects()
    {
        foreach (GameObject patternObject in instantiatedObjectsList)
        {
            patternObject.transform.Translate(Vector3.up * patternSpeed * Time.deltaTime);


        }


    }


    public void restart()
    {
        if (restartfactor == true)
        {
            patternSpeed = 0;
            RestartUI.SetActive(true);
            ScoreUItext.text = Totalscore.ToString();

            //reklam kontrolü
            isRestartUIActive = true;
        }
        else if (restartfactor == false)
        {
            RestartUI.SetActive(false);
            //reklam kontrolü
            isRestartUIActive = false;
        }
    }



    public void RestartScene()
    {
        Totalscore = 0;
        PlayerPrefs.SetInt(HighScoreKey, HighScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DisableCollidersForDuration(float duration)
    {
        foreach (GameObject patternObject in instantiatedObjectsList)
        {
            Collider collider = patternObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }

        yield return new WaitForSeconds(duration);

        foreach (GameObject patternObject in instantiatedObjectsList)
        {
            Collider collider = patternObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = true;
            }
        }

        isColliderDisabled = false;
    }

    public void soundsactiveMethodON()
    {

        music.SetActive(false);
        soundsactive.gameObject.SetActive(false);
        soundsdeactive.gameObject.SetActive(true);
        

    }

    public void soundactiveMethodOFF()
    {
        music.SetActive(true);
        soundsactive.gameObject.SetActive(true);
        soundsdeactive.gameObject.SetActive(false);
    }
}