using System.Linq;
using UnityEngine;

public class RollingStone : Obstacle
{
    private Vector3 direction;
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private float waveHeight = 100.0f;
    [SerializeField]
    private float waveWidth = 40.0f;

    private float birthTime;
    private float y0;
    private float startSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        direction = Vector3.left;
        startSpeed = speed;
    }
    public override void Start()
    {
        base.Start();
        birthTime = Time.time;
        y0 = transform.position.y;
    }

    // Update is called once per frame
    void Update() 
    {
        if(WindMaker.StormActive)
        {
            speed = startSpeed + 2.0f;
        }
        else
        {
            speed = startSpeed;
        }

        transform.Rotate(0, 0, 2.0f);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = y0 + Mathf.Abs(Mathf.Sin(Mathf.PI * 2 * (Time.time - birthTime) / waveWidth) * waveHeight);
        transform.position = pos;
        CheckObstacles();
    }

    private void CheckObstacles()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + (transform.right * -1.0f) * 3.0f, 0.1f);
        if (colliders.Length > 0 && colliders.Any(x => x.GetComponent<Obstacle>()))
        {
            speed = startSpeed + 3.0f;
        }

    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.GetComponent<Obstacle>() && collision.gameObject != this.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
