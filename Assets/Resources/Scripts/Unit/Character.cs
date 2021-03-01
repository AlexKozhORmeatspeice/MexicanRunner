using Assets.Scripts;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Character : Unit
{
    [SerializeField]
    private float rateSpeedChange = 60.0f;
    [SerializeField]
    private float jumpForce = 15.0f;

    private float baseSpeed;

    private float startTime;
    private SpriteRenderer sprite;
    private new Rigidbody2D rigidbody;
    private Animator animator;

    private bool isGrounded;

    private Vector3 moveDirection;

    private AudioSource stepSound;
    public AudioSource landingSound;
    public AudioSource jumpSound;
    public AudioMixer am;

    [SerializeField]
    private RuntimeAnimatorController[] controllers;

    private bool landed = false;

    private float distanceToTouches = 5.0f;
    //touchControllers
    private Vector2 startPos;
    private Vector2 direction;
    private bool directionChosen;
    public enum CharState
    {
        Idle,
        Run,
        Jump,
        run_in_croach
    }

    private CharState State
    {
        get { return (CharState)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }
    void Update()
    {
        animator.runtimeAnimatorController = controllers[(int)Data.nowUsebelPoncho];
        if (SceneManager.GetActiveScene().name == "Menu") return;
        if (WindMaker.StormActive)
        { 
            speed -= 2.0f;
        }
        if(Data.characterCrouched)
        {
            speed = 4.0f + (WindMaker.StormActive ? -2.0f : 0.0f);
        }
        Data.characterSpeed = speed;
        CheckGround();
        Run();
        CheackTouchs();


        if (Input.GetKeyDown(KeyCode.LeftControl)) { Jump(); }

        if (speed >= maxSpeed || Data.characterCrouched) return;
        speed = baseSpeed + (0.5f * ((Time.time - startTime)/ rateSpeedChange));
       
    }


    void Awake()
    {
        dead = false;
        stepSound = GetComponent<AudioSource>();
        baseSpeed = speed;
        sprite = GetComponentInChildren<SpriteRenderer>();
        isGrounded = true;
        moveDirection = Vector3.right;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Debug.Log(Data.nowUsebelPoncho.ToString());
        animator.runtimeAnimatorController = controllers[(int)Data.nowUsebelPoncho];
    }

    private void Start()
    {
        startTime = Time.time;
        switch((int)Data.nowUsebelPoncho)
        {
            case 0:
                break;
            case 1:
                Lives = 2;
                break;
            case 2:
                Lives = 3;
                break;
            case 3:
                Lives = 3;
                rateSpeedChange *= 1.5f;
                break;
            case 4:
                Lives = 4;
                break;
            case 5:
                Lives = 4;
                rateSpeedChange *= 2.0f;
                break;
        }
    }
    /////////////////////////////////MY FUCNCTIONS///////////////////////////////////////////////

    private void Run()
    {
        if (!stepSound.isPlaying && isGrounded)
        {
            if (!landed)
            {
                landingSound.Play();
                landed = true;
            }
            stepSound.pitch = Random.Range(0.8f, 1.1f);
            stepSound.Play();
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, speed * Time.deltaTime);

        sprite.flipX = moveDirection.x < 0.0f;


        if (isGrounded && State != CharState.run_in_croach) { State = CharState.Run; Data.characterCrouched = false; }
    }

    private void CheckGround()
    {
        Collider2D[] collliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        isGrounded = collliders.Length > 1;
        if (!isGrounded) { State = CharState.Jump; }
    }
    private void Jump()
    {
        jumpSound.Play();
        landed = false;
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void CheackTouchs()
    {
        if (dead) return; 
        if (Input.touchCount > 0)
        { 
            Touch touch = Input.GetTouch(0);  
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
           
            if(direction.y <= Vector2.down.y - distanceToTouches)
            {
                if (isGrounded && State == CharState.Run) { State = CharState.run_in_croach; Data.characterCrouched = true; }
                startPos = Vector2.zero;
                direction = Vector2.zero;
                directionChosen = false;
                return;
            }
            else if(direction.y >= Vector2.up.y + distanceToTouches)
            {
                if(isGrounded)State = CharState.Run;
                startPos = Vector2.zero;
                direction = Vector2.zero;
                directionChosen = false;
                return;
            }
            else
            {
                if (isGrounded)
                {
                    Jump();
                }
                startPos = Vector2.zero;
                direction = Vector2.zero;
                directionChosen = false;
                return;
            }

        }

    }
}

