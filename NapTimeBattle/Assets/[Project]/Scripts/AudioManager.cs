using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake() { instance = this; }
    private AudioSource _source;
    public AudioClip Hit;
    public AudioClip Daronage;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
