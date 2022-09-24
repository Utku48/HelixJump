using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpForce = 6;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();// audioManager = AudioManager Objesi
        //AudioManager'i oynatmak için kodlarda tek tek bulmak yerine burda bulup audioManager'in içine attık
        //audioManager.Play() yapmamız yeterli oldu 
    }


    void OnCollisionEnter(Collision collision)
    {



        //velocity: Objenin anlık hareketinin Vector3 cinsinden değeridir
        playerRB.velocity = new Vector3(playerRB.velocity.x, jumpForce, playerRB.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")//Top Yeşil renkli platforma vurdugunda
        {
            audioManager.Play("bounce");
        }
        else if (materialName == "Unsafe (Instance)")//Top Kırmızı renkli platforma vurdugunda
        {
            GameManager.gameOver = true;//GameManager Script'i içindeki gameOver'i ture yap
            audioManager.Play("GameOver");
        }
        else if (materialName == "LastRing (Instance)")//Top son platforma vurdugunda
                                                       //Level Tamamlanmış olur
        {
            Debug.Log("Level Tamamlandı");
            GameManager.levelComplated = true;//GameManager Script'i içindeki  levelCamplated'i ture yap
            audioManager.Play("WinLevel");
        }

    }


}
