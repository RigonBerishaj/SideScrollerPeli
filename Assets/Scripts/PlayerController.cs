using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle; // T‰ll‰ funktiolla pelin hahmolta tulee maasta likaa kun se juoksee.
    public AudioClip jumpSound; // Hyppy‰‰ni
    public AudioClip crashSound; // Tˆrm‰ys‰‰ni
    public AudioClip deathSound; // T‰m‰ ‰‰ni tapahtuu kun pelaaja kuolee.
    public float jumpForce; // Hyppyvoima jolla pelaaja voi s‰‰t‰‰ pelin hahmon hypyn korkeutta.
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    public void ResetPlayerState()
    {
        playerRb.velocity = Vector3.zero; // Resetoi kiihtyvyytt‰
        playerRb.angularVelocity = Vector3.zero;
        playerRb.isKinematic = false; // Pakottaa pelin hahmosta ei kinemaattisen rigidbodyn
        isOnGround = true; // Ensure player can jump immediately
        gameOver = false;
        playerAnim.SetBool("Death_b", false); // Resetoi animaattoria
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }
    }

    void Jump()
    {
        if (isOnGround && !gameOver)
        {
            Debug.Log($"Jumping with force: {jumpForce}"); // For debugging
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f); // Add jump sound here
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        dirtParticle.Play();
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over Lil Bro Go Back To Sleep :)"); //T‰m‰ teksti n‰kyy kun pelaaja h‰vi‰‰ pelin.
            gameOver = true;
            playerAudio.PlayOneShot(deathSound, 2.0f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetTrigger("Jump_trig");
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
