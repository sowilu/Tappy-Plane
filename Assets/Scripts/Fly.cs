using TMPro;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float jumpForce = 100;
    public TextMeshProUGUI scoreText;

    private Rigidbody2D rb;
    private int score = 0;

    void Start()
    {
        //GetComponent - access any component attached to the same game object
        rb = GetComponent<Rigidbody2D>();
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
    }
}
