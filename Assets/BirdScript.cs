using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D rigidbodyHere;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    [SerializeField] private AudioSource flapSoundEffect;
    [SerializeField] private AudioSource slapSoundEffect;
    [SerializeField] private AudioSource fallSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            rigidbodyHere.velocity = Vector2.up * flapStrength;
            flapSoundEffect.Play();

        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        slapSoundEffect.Play();
        fallSoundEffect.Play();
        logic.gameOver();
        birdIsAlive = false;
    }
}
