using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f; // [SerializeField] allows you to see the variable in the inspector
    private Animator animator;
    private bool isAlive;
    [SerializeField] private AudioClip flapAudio, dieAudio;
    [SerializeField] private AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && isAlive)
        {
            Flap();
        }
    }

    private void Flap()
    {
        rb.velocity = Vector2.zero; // Reset the velocity to zero to avoid adding up the force and making all jumps the same
        rb.velocity = Vector2.up * jumpForce;
        animator.SetTrigger("Flap");
        audioSource.clip = flapAudio; // Asignamos el sonido de flapAudio
        audioSource.Play(); // Reproducimos el sonido
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            isAlive = false;
            animator.SetTrigger("Die");
            audioSource.clip = dieAudio; // Asignamos el sonido de dieAudio
            audioSource.Play(); // Reproducimos el sonido
            GameManager.Instance.GameOver();
        }
    }
}
