using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MusicFilesNM;


public class BirdController : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    GameObject music;
    MusicFiles musicFiles;

    [SerializeField] float velocity = 5;
    public static bool isDead = false;
    public static int score;
    public static int highScore;

    private void Awake()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        music = GameObject.Find("audioManager");
        musicFiles = music.GetComponent(typeof(MusicFiles)) as MusicFiles;
    }


    // Update is called once per frame
    void Update()
    {
        //Fly little bird...
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
            animator.SetTrigger("isTap");
            AudioSource.PlayClipAtPoint(musicFiles.music[0], gameObject.transform.position);
        }
    }

    //You died little bird... :(
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || (collision.gameObject.CompareTag("Ground")))
        {
            isDead = true;
            AudioSource.PlayClipAtPoint(musicFiles.music[2], gameObject.transform.position);
            Invoke("gameover", 0.3f);
        }
    }

    //You earned a point!!! GG little bird! :)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            score++;
            AudioSource.PlayClipAtPoint(musicFiles.music[1], gameObject.transform.position);
        }
    }

    void gameover()
    {
        if (score > highScore)
        {
            highScore = score;
        }
        SceneManager.LoadScene("gameOVer");
    }
}
