using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public ScoreBoard scoreBoard;
    public float jumpForce = 100;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    public AudioClip successSound;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    
    void Start()
    {
        //Get components - gets any component attached to the game object
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.y < 0)
            {
                //Add force to the rigidbody
                //impulse - instant force, like a jump
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        //animations
        if(rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -30);
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        //Update the score
        scoreText.text = (++points).ToString("D4");

        //Play the success sound
        audioSource.PlayOneShot(successSound);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Show the score board
        scoreBoard.ShowScoreBoard(points);
        gameObject.SetActive(false);
    }
}
