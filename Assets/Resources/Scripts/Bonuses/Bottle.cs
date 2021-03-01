using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private AudioSource bonusMusic;

    private void Awake()
    {
        bonusMusic = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        if (character)
        {
            StartCoroutine(PlayOnDestroy());
        }
    }
    public virtual void Start()
    {
        Debug.Log("Made bottle");
        Invoke("DestroyObject", 30.0f);
    }

    private IEnumerator PlayOnDestroy()
    {
        if(Random.Range(0.0f, 1.0f) < 0.3f)
        {
            Data.BottlesCollected += 2;
        }
        else { Data.BottlesCollected++; }
        bonusMusic.Play();
        yield return new WaitForSeconds(bonusMusic.clip.length);
        Destroy(gameObject);
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
