using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //Eğer Ring posizyonu > player pozisyonu
        if (transform.position.y > player.position.y)
        {
            FindObjectOfType<AudioManager>().Play("whoosh");
            GameManager.numberOfPassedRing++;//Geçilen Ring sayısını 1 arttır.
            GameManager.score++;
            Destroy(gameObject);//Geçilen Ring'i yok et
        }
    }
}
