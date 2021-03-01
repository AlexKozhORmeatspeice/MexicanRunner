using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    protected int lives = 1;

    [SerializeField]
    protected float speed = 7.0f;
    [SerializeField]
    protected float maxSpeed = 8.0f;


    private float timeAtacked;
    public AudioSource deathSound;
    public AudioSource hitSound;

    static protected bool dead = false;

    public bool Dead
    {
        get { return dead; }
        set { dead = value; }
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value > 5)
            {
                lives = 5;
            }
            else
            {
                lives = value;
            }
        }
    }
    private void Start()
    {
        timeAtacked = 0.0f;
    }
    public void ReceiveDamage()
    {
        if (Time.time - timeAtacked > 2.0f)
        {
            timeAtacked = Time.time;
            Lives--;
            StartCoroutine(PlayOnHit());
            if (Lives <= 0)
            {
                dead = true;
                StartCoroutine(PlayOnDestroy());
            }
            Debug.Log($"Object: \"{this.gameObject.name}\", have {Lives} lives");
        }
    }


    private IEnumerator PlayOnHit()
    {
        hitSound.Play();
        if (gameObject.GetComponent<Character>())
        {
            Data.characterAtacked = true;
        }
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Color baseColor = sprite.color;
        sprite.color = Color.red;

        yield return new WaitForSeconds(hitSound.clip.length);
        sprite.color = baseColor;
        Data.characterAtacked = false;
    }

    private IEnumerator PlayOnDestroy()
    {
        deathSound.Play();
        //GetComponent<BoxCollider2D>().isTrigger = true;
        if (gameObject.GetComponent<Character>())
        {
            Time.timeScale = 0.0f;
        }
        yield return new WaitForSeconds(deathSound.clip.length);
        //Destroy(gameObject);
    }
}
