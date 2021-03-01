using System.Linq;
using UnityEngine;

public class RockOb : Obstacle
{
    [SerializeField]
    private float distToDeterm = 3.0f;

    private Vector3 startPos;

    private Animator animator;
    private bool activated = false;

    private bool notActiveForever;
    private Color rockColor;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated) return;
        base.OnTriggerEnter2D(collision);
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public override void Start()
    {
        base.Start();
        notActiveForever = Random.Range(0.0f, 1.0f) < 0.3f;
        GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        startPos = transform.position;
    }

    public void Update()
    {
        if (notActiveForever) return;
        if (activated)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(GetComponentInChildren<SpriteRenderer>().color, new Color(1.0f, 1.0f, 1.0f, 1.0f), 5.0f * Time.deltaTime);
            return;
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + (transform.right * -1.0f) * distToDeterm, 0.1f);
        if (colliders.Length > 0 && colliders.Any(x => x.GetComponent<Character>()))
        {
            activated = true;
            animator.SetBool("activated", true);
        }

    }
}
