using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float jumpForce = 100;
    public int score = 0;

    private Rigidbody2D rb;

    void Start()
    {
        //GetComponent can get the component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.y < 0)
            {
                //impulse is a force that is applied instantly, like throwing a ball
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            
        }

        //animations
        if(rb.velocity.y > 0)
        {
            //quaternion - rotation in 3D space
            //euler - transforms the rotation into a Vector3
            transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else
        {
           transform.rotation = Quaternion.Euler(0, 0, -30);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        score++;
        scoreText.text = score.ToString("D4");
    }

}
