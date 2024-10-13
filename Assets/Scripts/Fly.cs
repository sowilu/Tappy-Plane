using TMPro;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float jumpForce = 100;
    public TextMeshProUGUI scoreText;
    public AudioClip successSound;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private int score = 0;

    void Start()
    {
        //GetComponent - access any component attached to the same game object
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.y < 0)
            {
                //Impulse - instant force, like a punch
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        //animations - rotate the bird
        if(rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        scoreText.text = (++score).ToString("D4");
        audioSource.PlayOneShot(successSound);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        scoreManager.ShowScoreBoard(score);
        gameObject.SetActive(false);
    }
}
