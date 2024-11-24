using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake() { instance = this; }
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioSource _sourcePitch;
    public AudioClip Hit;
    public AudioClip Daronage;
    public AudioClip PickUp;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }

    public void PlayPitchUp(AudioClip clip)
    {
        _sourcePitch.PlayOneShot(clip);
    }
}
