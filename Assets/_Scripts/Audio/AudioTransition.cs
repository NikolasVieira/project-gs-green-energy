using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float transitionTime = .1f;

    public void MakeTransitino()
    {
        snapshot.TransitionTo(transitionTime);
    }
}
