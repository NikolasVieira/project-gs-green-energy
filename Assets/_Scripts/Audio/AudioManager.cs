using System;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetups;

    public AudioSource musicSource;

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }
}

public enum MusicType
{
    MENU,
    GAMING,
    SCREENPAUSE
}

[Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXType
{
    NONE,
    TYPE_01,
    TYPE_02,
    TYPE_03
}

[Serializable]
public class SFXSetup
{
    public SFXType sfxType;
    public AudioClip audioClip;
}