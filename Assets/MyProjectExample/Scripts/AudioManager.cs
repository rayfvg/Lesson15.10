using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private const float OffVolume = -80;
    private const float OnVolume = 0;

    private const string MusicKey = "MusicVolume";
    private const string SoundsKey = "SoundsVolume";

    [SerializeField] private AudioMixerGroup _masterGroup;

    [SerializeField] private AudioSource _audioSourceJump;
    [SerializeField] private AudioSource _audioSourceExplosion;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _preExplosion;

    private void Start() => _audioSourceMusic.Play();

    public void JumpSound() => _audioSourceJump.Play();

    public void ExsplosionSound() => _audioSourceExplosion.Play();

    public void PreExplosion() => _preExplosion.Play();

    public void OnOffMusic(bool toggle)
    {
        if (toggle)
            _masterGroup.audioMixer.SetFloat(MusicKey, OnVolume);
        else
            _masterGroup.audioMixer.SetFloat(MusicKey, OffVolume);
    }

    public void OnOffSound(bool toggle)
    {
        if (toggle)
            _masterGroup.audioMixer.SetFloat(SoundsKey, OnVolume);
        else
            _masterGroup.audioMixer.SetFloat(SoundsKey, OffVolume);
    }
}