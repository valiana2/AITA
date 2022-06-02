using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFish1 : MonoBehaviour
{
    public float playerSpeed;
    private float lastXPosition;
    public GameObject gameController;
    public AudioClip SfxCorrect;
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        lastXPosition = transform.position.x;
    }

    private void Awake() 
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float changeInX = transform.position.x + (Input.GetAxis("Horizontal") * playerSpeed);
        float changeInY = transform.position.y + (Input.GetAxis("Vertical") * playerSpeed);

        transform.position = new Vector3(changeInX, changeInY);

        if(transform.position.x < lastXPosition)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(transform.position.x > lastXPosition)
        {
            transform.localScale = new Vector2(1, 1);
        }

        lastXPosition = transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "food")
        {
            audiosource.PlayOneShot(SfxCorrect);
            gameController.GetComponent<GameControl>().SendMessage("IncreaseScore");
            Destroy(collision.gameObject);
        }
    }
}
