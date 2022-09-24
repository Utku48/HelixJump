using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplated;
    public static bool isGameStarted;
    public static bool mute = false;

    public GameObject gameOverPanel;
    public GameObject levelComplatedPanel;
    public GameObject gamePlayPanel;
    public GameObject StartMenuPanel;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    public static int numberOfPassedRing; //Geçilen Ring sayısı,Slider'ın içini arrtırmak için gerekli
    public static int score = 0;


    public void Awake()//Awake fonksiyonu ilk önce çalışan fonskiyonumuzdur.
    {
        //Oyun basladıgında kaçıncı seviyede oldugumuzu CurrentLvl içinde gösterir.

        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 0);
    }


    void Start()
    {
        Time.timeScale = 1;//Oyun'a Tekrar basladıgımızda oyunun devam etmesi için
        numberOfPassedRing = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("High Score", 0);
        isGameStarted = levelComplated = gameOver = false;


    }

    // Update is called once per frame
    void Update()
    {
        //Update UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();
        int progress = numberOfPassedRing * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();

        if (Input.GetMouseButtonDown(0) && !isGameStarted)

        {
            if (EventSystem.current.IsPointerOverGameObject()) //Mouse UI elementine mi bastı kontrol et ?
                return;

            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            StartMenuPanel.SetActive(false);

        }


        if (gameOver)
        {
            Time.timeScale = 0;//=>Oyunu Durdurur

            gameOverPanel.SetActive(true);//GameOverPanel'i Aktif Edilir
            if (Input.GetButtonDown("Fire1"))
            {

                //Eğer NewScore> Current HighScore'dan. score==HighScore olur
                if (score > PlayerPrefs.GetInt("High Score", 0))
                {
                    PlayerPrefs.SetInt("High Score", score);
                }


                score = 0; //Eğer "Game Over" oldu ise score'u 0 a eşitle
                SceneManager.LoadScene("Level");
            }
        }

        if (levelComplated)
        {
            Time.timeScale = 0;
            levelComplatedPanel.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);//Level Kutucugundaki sayılar artacak
                SceneManager.LoadScene("Level");
            }

        }
    }
}
