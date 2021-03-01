using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private bool canDestroy = true;


    private AudioSource breakingSound;
    private SpriteRenderer sprite;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        if (character)
        {
            character.ReceiveDamage();
            Rigidbody2D rg = character.GetComponent<Rigidbody2D>();
            rg.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            rg.AddForce(Vector2.left * (character.GetComponentInChildren<SpriteRenderer>().flipX ? -1.0f : 1.0f) * 15.0f, ForceMode2D.Impulse);
            rg.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);
            StartCoroutine(PlayOnDestroy());
        }
    }

    public virtual void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

        breakingSound = GetComponent<AudioSource>();
        Invoke("DestroyObject", 30.0f);
    }

    private IEnumerator PlayOnDestroy() // не играет звук, поправь
    {
        if (breakingSound != null) breakingSound.Play();
        //yield return new WaitForSeconds(breakingSound != null ? breakingSound.clip.length : 0.5f);
        while(sprite.color.a >= 0)
        {
            Color c = sprite.color;
            c.a = Mathf.Lerp(c.a, c.a - 0.05f, 1.0f);
            sprite.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        if (canDestroy) Destroy(gameObject);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
