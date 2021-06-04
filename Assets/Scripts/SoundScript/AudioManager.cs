using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        // if (instance == null) {
        // } else {
        //     Destroy(gameObject);
        //     return;
        // }
        
        // DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.output;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {
        Play("MainTheme");
    }

    public void Play(string name) {
        foreach (Sound s in sounds)
        {
            if (s == null) {
                Debug.Log("Sound not found");
                return;
            }
            if (s.name == name) {
                s.source.Play();
                break;
            }
        }
        // Sound s = Array.Find(sounds, sound => sound.name == name);
    }

    public void Stop(string name) {
        foreach (Sound s in sounds)
        {
            if (s == null) {
                Debug.Log("Sound not found");
                return;
            }
            if (s.name == name) {
                s.source.Stop();
                break;
            }
        }
    }
}
