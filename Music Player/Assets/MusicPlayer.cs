using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicPlayer : MonoBehaviour
{
    [SerializeField] Text songName;
    [SerializeField] Text currentTime;
    [SerializeField] Text totalLenght;
    [SerializeField] Text playButtonText;
    [SerializeField] Slider durationSlider;


    [SerializeField] List<AudioClip> clips = new List<AudioClip>();

    AudioSource _audioSource;

    int _currentSong = 0;
    int lenghtMinute;
    int lenghtSeconds;
    int durationMinute;
    int durationSeconds;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    void Update()
    {
        CalculateDuration();

        if(_audioSource.time == clips[_currentSong].length)
        {
            NextMusic();
        }
    }

    void CalculateLenght()
    {
        lenghtMinute = (int)clips[_currentSong].length / 60;
        lenghtSeconds = (int)clips[_currentSong].length % 60;
        durationSlider.maxValue = (int)clips[_currentSong].length;
        totalLenght.text = lenghtMinute.ToString() + ":" + lenghtSeconds.ToString();
    }

    public void PlayMusic()
    {
        _audioSource.clip = clips[_currentSong];
        _audioSource.Play();
        CalculateLenght();
        UpdateMusicText();
    }

    void CalculateSlider()
    {
        durationSlider.value = _audioSource.time ;
    }

    void CalculateDuration()
    {
        durationMinute = (int)_audioSource.time / 60;
        durationSeconds = (int)_audioSource.time % 60;

        currentTime.text = durationMinute.ToString() + ":" + durationSeconds.ToString();
    }

    public void PreviousMusic()
    {
        if(_currentSong == 0)
        {
            _currentSong = clips.Count - 1;
        }
        else
        {
            _currentSong--;
        }
        PlayMusic();
    }

    public void PlayPause()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Pause();
            playButtonText.text = "|>";
        }
        else
        {
            _audioSource.Play();
            playButtonText.text = "||";

        }
    }

    void UpdateMusicText()
    {
        songName.text = clips[_currentSong].name;
    }



    public void NextMusic()
    {
        if(_currentSong == clips.Count - 1)
        {
            _currentSong = 0;
        }
        else
        {
            _currentSong++; 
        }
        PlayMusic();
    } 





}
