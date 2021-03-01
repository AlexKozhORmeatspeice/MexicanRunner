using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public Vector3 direction;

    private float speed;
    private float baseSpeed;

    [SerializeField]
    private float maxSpeed = 4.0f;
    [SerializeField]
    private float minSpeed = 2.0f;


    // Start is called before the first frame update
    void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        baseSpeed = speed;
        direction = Vector3.left;
    }

    void Update()
    {
        if (WindMaker.StormActive) speed = baseSpeed + 10.0f;
        else speed = baseSpeed;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
