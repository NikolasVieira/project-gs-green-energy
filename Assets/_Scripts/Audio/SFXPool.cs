using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class SFXPool : Singleton<SFXPool>
{
    private List<AudioSource> _audioSourceList;

    public int poolSize = 10;

    private int _index = 0;

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _audioSourceList = new List<AudioSource>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem()
    {
        GameObject gameObject = new GameObject("SFX_Pool");
        gameObject.transform.SetParent(gameObject.transform);
        _audioSourceList.Add(gameObject.AddComponent<AudioSource>());
    }

    public void Play(SFXType sfxType)
    {
        if (sfxType == SFXType.NONE) return;

        var sfx = SoundManager.Instance.GetSFXByType(sfxType);

        _audioSourceList[_index].clip = sfx.audioClip;
        _audioSourceList[_index].Play();

        _index++;
        if (_index >= _audioSourceList.Count) _index = 0;
    }
}
