using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; 
    public AudioClip unitDead;
    public AudioClip unitSpawn;
    public AudioClip unitDamage;
    public AudioClip bonusSpawn;
    public AudioClip playerScores;
    public AudioClip mlAgentScores;
    public AudioClip endGame;
    private AudioSource audioSource;
    
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayUnitDeadSound()
    {
        audioSource.PlayOneShot(unitDead);
    }

    public void PlayUnitSpawnSound()
    {
        audioSource.PlayOneShot(unitSpawn);
    }

    public void PlayUnitDamageSound()
    {
        audioSource.PlayOneShot(unitDamage);
    }

    public void PlayBonusSpawnSound()
    {
        audioSource.PlayOneShot(bonusSpawn);
    }

    public void PlayPlayerScoresSound()
    {
        audioSource.PlayOneShot(playerScores);
    }

    public void PlayMLAgentScoresSound()
    {
        audioSource.PlayOneShot(mlAgentScores);
    }

    public void PlayEndGameSound()
    {
        audioSource.PlayOneShot(endGame);
    }
}
