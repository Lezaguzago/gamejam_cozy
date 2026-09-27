using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundFXObject;
    public static SFXManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTranform, float volume)
    {
        //spawn in GameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTranform.position, Quaternion.identity);

        //assign the audioClip
        audioSource.clip = audioClip;

        //assing volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get the length of sound FX clip
        float cliplenth = audioSource.clip.length;

        audioSource.pitch = Random.Range(0.95f, 1.05f);
        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, cliplenth);

    }
}
