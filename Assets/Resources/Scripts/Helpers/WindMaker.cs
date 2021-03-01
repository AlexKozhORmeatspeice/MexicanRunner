using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindMaker : MonoBehaviour
{
    private AudioSource stormSound;
    [SerializeField]
    private float timeBeetwenSpawns = 30.0f;

    static private bool stormActive = false;

    static public bool StormActive
    {
        get { return stormActive; }
        private set { stormActive = value; }
    }
    private void Awake()
    {
        stormSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Game") { stormActive = false; return; }
        Invoke("MakeStorm", timeBeetwenSpawns);
    }

    private void MakeStorm()
    {

        StartCoroutine(Stormer());
    }

    private IEnumerator Stormer()
    {
        stormSound.Play();

        yield return new WaitForSeconds(1.5f);
        StormActive = true;

        yield return new WaitForSeconds(stormSound.clip.length - 1.5f);
        StormActive = false;
    }


}
