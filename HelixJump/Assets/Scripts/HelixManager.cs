using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;//Yukarıdan asagı Spawn
    public float ringsDistance = 5;//Halkalar mesafesi
    public int numberOfRings = 7;//Halka Sayısı
    public GameObject LastRing;
    void Start()
    {
        {
            numberOfRings = GameManager.currentLevelIndex + 5;
            //HelixRing'leri spawnlar
            for (int i = 0; i < numberOfRings; i++)
                if (i == 0)
                    SpawnRing(0);
                else
                    SpawnRing(Random.Range(0, helixRings.Length - 1));
            //HelixRing içindekileri 0. indeksten Ring sayısı -1 e kadar olan Ringleri Rasgele Sıralayacak
            //-1 olmasının sebebi son indexte LastRing bulunmasıdır. Eğer LastRing'i de random atarsa,LastRing 3. veya 4. Ring olabilir
        }
        //Last Ring'i Spawnlar
        SpawnRing(helixRings.Length - 1);

    }

    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringsDistance;
    }
}
