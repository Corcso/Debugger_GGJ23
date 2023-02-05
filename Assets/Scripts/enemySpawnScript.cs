using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using Random = UnityEngine.Random;


public class enemySpawnScript : MonoBehaviour
{
    public gameManager gameManager;

    public Transform playerTransform;

    public GameObject bugPrefab;
    public float bugInterval = 2;
    float timeSinceLastSpawn = 0;

    public GameObject miniBugPrefab;
    public float miniBugInterval = 4;
    float timeSinceLastMiniSpawn = 0;

    public GameObject megaBugPrefab;
    public float megaBugInterval = 60;
    float timeSinceLastMegaSpawn = 0;

    Vector2 spawnMin = new Vector2(10, 6);
    Vector2 spawnMax = new Vector2(40, 36);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState == gameManager.gameState.paused)
        {
            return;
        }

        if (gameManager.currentGameState == gameManager.gameState.playing)
        {
            bugInterval = 1 / (0.7f * Mathf.Log(gameManager.difficulty + 1));

            if (Time.realtimeSinceStartup >= timeSinceLastSpawn + bugInterval)
            {
                timeSinceLastSpawn = Time.realtimeSinceStartup;

                float spawnX = Random.Range(spawnMin.x + playerTransform.position.x, spawnMax.x + playerTransform.position.x);
                float spawnY = Random.Range(spawnMin.y + playerTransform.position.y, spawnMax.y + playerTransform.position.y);

                if (Random.Range(0, 2) == 0)
                {
                    spawnX = Random.Range(-spawnMin.x + playerTransform.position.x, -spawnMax.x + playerTransform.position.x);
                }
                if (Random.Range(0, 2) == 0)
                {
                    spawnY = Random.Range(-spawnMin.y + playerTransform.position.y, -spawnMax.y + playerTransform.position.y);
                }
                if (Random.Range(0, 2) == 0)
                {
                    spawnX = Random.Range(-spawnMax.x + playerTransform.position.x, spawnMax.x + playerTransform.position.x);
                }
                else
                {
                    spawnY = Random.Range(-spawnMax.y + playerTransform.position.y, spawnMax.y + playerTransform.position.y);
                }

                spawnX = Mathf.Clamp(spawnX, -60, 60);
                spawnY = Mathf.Clamp(spawnY, -60, 60);

                GameObject bug = Instantiate(bugPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0, 0, 0));

                bug.GetComponent<bugController>().playerTransform = playerTransform;

                
            }

            miniBugInterval = 1 / (0.1f * Mathf.Log(gameManager.difficulty + 1));

            if (Time.realtimeSinceStartup >= timeSinceLastMiniSpawn + miniBugInterval && gameManager.difficulty > 2.5f)
            {
                timeSinceLastMiniSpawn = Time.realtimeSinceStartup;

                float spawnX = Random.Range(spawnMin.x + playerTransform.position.x, spawnMax.x + playerTransform.position.x);
                float spawnY = Random.Range(spawnMin.y + playerTransform.position.y, spawnMax.y + playerTransform.position.y);

                if (Random.Range(0, 2) == 0)
                {
                    spawnX = Random.Range(-spawnMin.x + playerTransform.position.x, -spawnMax.x + playerTransform.position.x);
                }
                if (Random.Range(0, 2) == 0)
                {
                    spawnY = Random.Range(-spawnMin.y + playerTransform.position.y, -spawnMax.y + playerTransform.position.y);
                }
                if (Random.Range(0, 2) == 0)
                {
                    spawnX = Random.Range(-spawnMax.x + playerTransform.position.x, spawnMax.x + playerTransform.position.x);
                }
                else
                {
                    spawnY = Random.Range(-spawnMax.y + playerTransform.position.y, spawnMax.y + playerTransform.position.y);
                }

                spawnX = Mathf.Clamp(spawnX, -55, 55);
                spawnY = Mathf.Clamp(spawnY, -55, 55);


                for (float i = 0; i < 1.5f; i += 0.5f)
                {
                    for (float j = 0; j < 1.5f; j += 0.5f)
                    {
                        GameObject bug = Instantiate(miniBugPrefab, new Vector3(spawnX + i, spawnY + j, 0), Quaternion.Euler(0, 0, 0));
                        bug.GetComponent<miniBugControler>().playerTransform = playerTransform;
                    }
                }

            }


            megaBugInterval = 75f / (Mathf.Log(gameManager.difficulty + 1));

            if (Time.realtimeSinceStartup >= timeSinceLastMegaSpawn + megaBugInterval && gameManager.difficulty > 3f)
            {
                timeSinceLastMegaSpawn = Time.realtimeSinceStartup;

                float spawnX = Random.Range(spawnMin.x + playerTransform.position.x, spawnMax.x + playerTransform.position.x);
                float spawnY = Random.Range(spawnMin.y + playerTransform.position.y, spawnMax.y + playerTransform.position.y);

                if (Random.Range(0, 2) == 0)
                {
                    spawnX = Random.Range(-spawnMin.x + playerTransform.position.x, -spawnMax.x + playerTransform.position.x);
                }
                if (Random.Range(0, 2) == 0)
                {
                    spawnY = Random.Range(-spawnMin.y + playerTransform.position.y, -spawnMax.y + playerTransform.position.y);
                }
                if (Random.Range(0, 2) == 0)
                {
                    spawnX = Random.Range(-spawnMax.x + playerTransform.position.x, spawnMax.x + playerTransform.position.x);
                }
                else
                {
                    spawnY = Random.Range(-spawnMax.y + playerTransform.position.y, spawnMax.y + playerTransform.position.y);
                }

                spawnX = Mathf.Clamp(spawnX, -55, 55);
                spawnY = Mathf.Clamp(spawnY, -55, 55);


                GameObject bug = Instantiate(megaBugPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0, 0, 0));
                bug.GetComponent<megaBug>().playerTransform = playerTransform;

            }
        }
    }
}
