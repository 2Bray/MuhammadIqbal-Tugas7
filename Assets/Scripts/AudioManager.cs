using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _bgmAudioSource;
    public bool isAudioEnabled = false;
    private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void PlayBgm()
    {
        int r = Random.Range(0, _bgmAudioSource.Count);

        for (int i = 0; i < _bgmAudioSource.Count; i++)
        {
            if (i != r) Destroy(_bgmAudioSource[i].gameObject);
        }

        Resources.Load("Assets/Audio/Resources/BGM/BGM_0" + (r + 1));
        _bgmAudioSource[r].Play();
    }

    public void DestroyAllBGM()
    {
        for (int i = 0; i < _bgmAudioSource.Count; i++)
        {
            Destroy(_bgmAudioSource[i].gameObject);
        }
    }
}
