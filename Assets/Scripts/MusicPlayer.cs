using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* Singleton pattern implementation */
        
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>().Length;

        if (numOfMusicPlayers>1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
        
    }

    
}
