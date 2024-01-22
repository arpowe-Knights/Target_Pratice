using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public static CursorController Instance { get; set; }

    private SpriteRenderer rend;
    public Sprite shootingCursor;

    public ParticleSystem particleSystem;

    public AudioSource audioSource;

    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();

        // Set the initial position of the custom cursor to the mouse position
        Vector3 initialCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        initialCursorPos.z = 0f;
        transform.position = initialCursorPos;

        Instance = this;
    }

    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0f;

        // Move the custom cursor to the mouse position
        transform.position = cursorPos;
    }

    public void EmitParticles(int amount)
    {
        particleSystem.Emit(amount);
    }

    public void ShootSound()
    {
        audioSource.Play();
    }
}
