using System.Collections;
using UnityEngine;

public class Cuerda : MonoBehaviour {

    public GameObject _fireParticles;
    private PlayerController _player;
    public Rigidbody2D _objectAtatch;
    public PuzzleSolved _puerta;

	void Awake ()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _objectAtatch.bodyType = RigidbodyType2D.Static;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && _player._player != 1)
        {            
            GameObject particles = Instantiate(_fireParticles, transform);
            ParticleSystem fire = particles.GetComponent<ParticleSystem>();

            var sh = fire.shape;
            float lenth = GetComponent<SpriteRenderer>().size.y / 2;
            sh.radius = lenth;
            sh.position = new Vector2(0, -lenth);

            StartCoroutine(DestroyRope(fire));
        }
    }
    IEnumerator DestroyRope(ParticleSystem fire)
    {
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitUntil(() => fire.particleCount >= 20);
        
        _objectAtatch.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<SpriteRenderer>().enabled = false;
        
        yield return new WaitForSeconds(fire.main.startLifetime.constant);
        
        _puerta._puzzleSolved = true;
        Destroy(this.gameObject);
    }
}