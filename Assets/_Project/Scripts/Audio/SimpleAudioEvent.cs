using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Simple Event")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] _clips;
    
    [MinMaxRange(0, 1)] public FloatRange _volume = new FloatRange(1, 1);
    [MinMaxRange(0, 2)] public FloatRange _pitch =  new FloatRange(1, 1);

    public override void Play(AudioSource source)
    {
        if (_clips.Length == 0) return;

        source.clip = _clips[Random.Range(0, _clips.Length)];
        source.volume = Random.Range(_volume.Min, _volume.Max);
        source.pitch = Random.Range(_pitch.Min, _pitch.Max);
        source.Play();
    }
}
