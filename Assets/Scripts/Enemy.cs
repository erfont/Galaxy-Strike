using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    private void OnParticleCollision(GameObject other) 
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity); // Quaternion identity is the default 1, 1, 1 rotation
        Destroy(this.gameObject);    
    }
}
