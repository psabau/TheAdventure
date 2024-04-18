using System;
using NAudio.Wave;

public class MusicPlayer
{
    private WaveOutEvent _outputDevice;
    private AudioFileReader _audioFile;
    private float _volume = 0.5f;
    
    public MusicPlayer()
    {
        _outputDevice = new WaveOutEvent();
    }
    
    public float CurrentVolume
    {
        get => _volume;
        set => SetVolume(value);
    }
    
    

    public void PlayMusic(string filePath)
    {
        _audioFile?.Dispose();
        
        if (_outputDevice.PlaybackState == PlaybackState.Playing)
        {
            _outputDevice.Stop();
        }
        _audioFile = new AudioFileReader(filePath);
        _outputDevice.Init(_audioFile);
        _outputDevice.Play();
        
        _outputDevice.Volume = _volume;
    }

    public void StopMusic()
    {
        _outputDevice.Stop();
    }
    

    public void SetVolume(float volume)
    {
        _volume = Math.Clamp(volume, 0.0f, 1.0f);
        _outputDevice.Volume = _volume;
    }
}