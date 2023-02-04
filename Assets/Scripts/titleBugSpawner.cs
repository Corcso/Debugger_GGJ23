using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleBugSpawner : MonoBehaviour
{ 

    public GameObject bugPrefab;
    public float bugInterval = 2;
    float timeSinceLastSpawn = 0;
    Vector2 spawnMin = new Vector2(10, 6);
    Vector2 spawnMax = new Vector2(11, 7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup >= timeSinceLastSpawn + bugInterval)
        {
            timeSinceLastSpawn = Time.realtimeSinceStartup;

            float spawnX = Random.Range(spawnMin.x, spawnMax.x);
            float spawnY = Random.Range(spawnMin.y, spawnMax.y);

            if (Random.Range(0, 2) == 0)
            {
                spawnX = Random.Range(-spawnMin.x, -spawnMax.x);
            }
            if (Random.Range(0, 2) == 0)
            {
                spawnY = Random.Range(-spawnMin.y, -spawnMax.y);
            }
            if (Random.Range(0, 2) == 0)
            {
                spawnX = Random.Range(-spawnMax.x, spawnMax.x);
            }
            else
            {
                spawnY = Random.Range(-spawnMax.y, spawnMax.y);
            }

            GameObject bug = Instantiate(bugPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0, 0, 0));

            float wantX = 0;
            float wantY = 0;
            while (wantX == 0 && wantY == 0){
                wantX = Random.Range(0, 5);
                wantY = Random.Range(0, 5);
            }

            wantX *= Mathf.Sign(spawnX) * -1;
            wantY *= Mathf.Sign(spawnY) * -1;

            bug.GetComponent<titleBugController>().wantX = wantX;
            bug.GetComponent<titleBugController>().wantY = wantY;
            Destroy(bug, 25);


        }
    }
}
