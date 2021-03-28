using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject manDarkPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemies(int enemiesQnt)
    {
        for (int i = 0; i < enemiesQnt; ++i)
        {
            Instantiate(manDarkPrefab, GeneratePositionWithCheck(), manDarkPrefab.transform.rotation);
        }
    }

    private Vector3 GeneratePositionWithCheck()
    {
        GameObject[] mansOnBoard = GameObject.FindGameObjectsWithTag("Man");
        Vector3 newPosition;
        bool isColliding = false;
        do
        {
            newPosition = GeneratePosition();
            foreach (GameObject man in mansOnBoard)
            {
                Debug.Log($"{man.gameObject.transform.position.Equals(newPosition)}");
                if (man.gameObject.transform.position.Equals(newPosition))
                {
                    isColliding = true;
                    break;
                }
                isColliding = false;
            }
        } while (isColliding);
        return newPosition;
    }

    private Vector3 GeneratePosition()
    {
        int prePosX = Random.Range(0, 10);
        float spawnPosX = prePosX - 4.5f;
        int prePosZ = Random.Range(0, 5);
        float spawnPosZ = prePosZ * 2 + prePosX % 2 - 4.5f;
        float spawnPosY = 0.2f;
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }
}
