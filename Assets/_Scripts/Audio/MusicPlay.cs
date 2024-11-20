using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    public MusicType musicType;
    public AudioSource audioSource;

    private MusicSetup _currentMusicSetup;

    private void Start()
    {
        Play();
    }

    private void Play()
    {
        _currentMusicSetup = SoundManager.Instance.GetMusicByType(musicType);

        audioSource.clip = _currentMusicSetup.audioClip;
        audioSource.Play();
    }
}
