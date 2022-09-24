using TMPro;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    void Start()
    {
        if (GameManager.mute)

            soundsText.text = "/";
        else
            soundsText.text = "";
    }

    void Update() //Quit Butonuna bastıgımızda oyunun durma kodu
    {
        if (Input.GetKeyDown(0))
        {
            QuitGame();
        }
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;

    }


    public void ToggleMute()//Oyunu Mute'leyecegimiz kod
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundsText.text = "/";

        }
    }


}
