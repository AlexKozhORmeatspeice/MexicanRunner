using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreator : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> blocksList = new List<GameObject>();

    [SerializeField]
    public List<GameObject> bonusesList = new List<GameObject>();
    [SerializeField]
    private GameObject[] obstacles;

    public GameObject partition;

    private float distanceBetBlocks;
    private List<GameObject> blocks = new List<GameObject>();
    private int numberOfBlockInFrame;

    private float obstacleSpawnTime = 0;
    [SerializeField]
    private float averageTimeBeetwenSpawns = 5.0f;
    private float nowSpawntime = 0.0f;
    private void Start()
    {
        distanceBetBlocks = blocksList[0].GetComponent<BoxCollider2D>().size.x;
        numberOfBlockInFrame = Mathf.RoundToInt((Camera.main.orthographicSize * 2 * Camera.main.aspect) / distanceBetBlocks) + 7;
        nowSpawntime = Random.Range(averageTimeBeetwenSpawns - 1.0f, averageTimeBeetwenSpawns + 1.0f);
        MakeGround();
    }


    private void MakeGround() 
    {
        for (int i = 0; i <= numberOfBlockInFrame; i++)
        {
            Vector3 pos = transform.position;
            pos.x += distanceBetBlocks * i;
            pos.z = 0;
            blocks.Add(Instantiate(blocksList[Random.Range(0,2)], pos, Quaternion.identity));
        }
    }


    private void Update()
    {
        if (Data.characterAtacked)
        {
            obstacleSpawnTime = Time.time;
            Debug.Log(obstacleSpawnTime);
        }
        CheckBloks();
    }



    private void CheckBloks()
    {
        foreach (GameObject b in blocks)
        {
            if (b.transform.position.x <= transform.position.x - distanceBetBlocks * 3)
            {
                Destroy(blocks[0]);
                blocks.RemoveAt(0);
                Vector3 pos = transform.position;
                pos.x += distanceBetBlocks * (numberOfBlockInFrame - 3);
                pos.z = 0;
                blocks.Add(Instantiate(blocksList[Random.Range(0, 2)], pos, Quaternion.identity));

                MakeObstacle(pos);
                return;
            }
        }

    }
     
    private void SpawnBonus(Vector3 pos)
    {
        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            Instantiate(bonusesList[0], pos, Quaternion.identity);
        }

    }
    private void MakeObstacle(Vector3 pos)
    {
        if (Time.time - obstacleSpawnTime > nowSpawntime)
        {
            nowSpawntime = Random.Range(averageTimeBeetwenSpawns - 0.5f, averageTimeBeetwenSpawns + 0.5f);
            obstacleSpawnTime = Time.time;
            GameObject obs;
            obs = obstacles[Random.Range(0, 3)];
            Debug.Log(obs.name);


            if (obs.GetComponent<Obstacle>() && !obs.GetComponent<RockOb>() && !obs.GetComponent<RollingStone>())
            {
                pos.y += blocksList[0].GetComponent<BoxCollider2D>().size.y + 0.5f;
                if (Random.Range(0.0f, 1.0f) <= 0.2f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Instantiate(obs, pos, Quaternion.identity);
                        if (Data.characterSpeed > 5.0f) { pos.x += distanceBetBlocks * 7; }
                        else if (Data.characterSpeed > 7.5f) { pos.x += distanceBetBlocks * 8; }
                        else { pos.x += distanceBetBlocks * 5; }
                    }
                    nowSpawntime += 5.0f;
                }
                else
                {
                    if (Random.Range(0.0f, 1.0f) < 0.2)
                    {
                        //pos.y = -3.31f;
                        Instantiate(partition, pos, Quaternion.identity);
                        return;
                    }
                    Instantiate(obs, pos, Quaternion.identity);
                    if (Random.Range(0.0f, 1.0f) > 0.5f)
                    {
                        if (Data.characterSpeed > 5)
                        {
                            pos.x -= distanceBetBlocks * 3;
                        }
                        else
                        {
                            pos.x -= distanceBetBlocks * 2;
                        }
                        //pos.y = -3.31f;
                        Instantiate(partition, pos, Quaternion.identity);

                        pos.x -= distanceBetBlocks * 2;
                        SpawnBonus(pos);
                    }
                }
                return;
            }

            if (obs.GetComponent<RockOb>())
            {
                pos.y += blocksList[0].GetComponent<BoxCollider2D>().size.y;
                Instantiate(obs, pos, Quaternion.identity);
                SpawnBonus(pos);
                return;
            }

            if (obs.GetComponent<RollingStone>())
            {
                pos.y += blocksList[0].GetComponent<BoxCollider2D>().size.y;
                pos.x += 3.0f;
                Instantiate(obs, pos, Quaternion.identity);
                SpawnBonus(pos);
                return;
            }
        }
    }

}
