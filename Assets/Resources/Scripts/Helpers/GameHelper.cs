using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameHelper : MonoBehaviour
{
    public GameObject[] typeOfClouds;

    public static List<GameObject> clouds;

    [SerializeField]
    private int maxCountOfClouds = 8;
    [SerializeField]
    private int minCountOfCLouds = 5;
    private int nowMaxClouds;
    private GameObject sreenBorderRight;
    private float camHeight;
    private float camWidth;

    void Awake()
    {
        clouds = new List<GameObject>();
        sreenBorderRight = GameObject.Find("borderRight");
        nowMaxClouds = Random.Range(minCountOfCLouds, maxCountOfClouds);
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
        MakeClouds();

    }
    private void LateUpdate() //checks if the object is within bounds
    {
        List<int> indexs = new List<int>();
        int index = 0;
        foreach (GameObject cloud in clouds)
        {
            Vector3 pos = cloud.transform.position;
            if (pos.x <= sreenBorderRight.transform.position.x)
            {
                indexs.Add(index);
            }
            index++;
        }

        if (indexs != null)
        {
            Vector3 pos = transform.position;
            pos.x += 2.0f;
            pos.z = 0;
            foreach (int i in indexs)
            {
                pos.y = clouds[i].transform.position.y * 1.0f;
                clouds[i].transform.position = pos;
            }
        }
    }
    private void MakeClouds()
    {
        Debug.Log($"{camHeight} && {camWidth}");
        for (int i = 0; i < nowMaxClouds; i++)
        {
            GameObject cloud;
            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                cloud = Instantiate(typeOfClouds[0], new Vector3(transform.position.x - (Random.Range(0, camWidth * 2)),
                                     transform.position.y + Random.Range(-2.0f, 2.0f), 0),
                                     Quaternion.identity);

            }
            else
            {
                cloud = Instantiate(typeOfClouds[1], new Vector3(transform.position.x - (Random.Range(0, camWidth * 2)),
                                     transform.position.y + Random.Range(-2.0f, 2.0f), 0),
                                     Quaternion.identity);

            }
            clouds.Add(cloud);
        }
    }
}
