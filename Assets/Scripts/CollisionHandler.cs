using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameSceneManager gameSceneManager;

    void Start()
    {
        gameSceneManager = FindAnyObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity); // Quaternion identity is the default 1, 1, 1 rotation

        gameSceneManager.ReloadLevel();

        Destroy(this.gameObject);   
    }
}
