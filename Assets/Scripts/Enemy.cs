using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoints = 4;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindAnyObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        hitPoints--;
        
        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity); // Quaternion identity is the default 1, 1, 1 rotation
            Destroy(this.gameObject);
        } 
        else Instantiate(hitVFX, transform.position, Quaternion.identity);
    }
}
