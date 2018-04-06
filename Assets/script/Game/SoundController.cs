using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
    public bool haveSound           = true;

    [Header("General Sounds")]
    public AudioClip GeneralSound   = null;

    [Header("Ball Sounds")]
    public AudioClip WallSound      = null;
    public AudioClip PaddleSound    = null;
    public AudioClip VictorySound   = null;
    public AudioClip PointSound     = null;

    AudioSource generalAudioSource  = null;
    AudioSource notifAudioSource    = null;
    // Use this for initialization
    void Start ()
    {
        AddAudioSourceAndPlayGeneralSound();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    #region General Sound & config source
    public void AddAudioSourceAndPlayGeneralSound()
    {
        if (!haveSound)
            return;

        AddAudioSource();
        RunGeneralSound(GeneralSound);
    }

    public void AddAudioSource()
    {
        if (generalAudioSource == null)
            generalAudioSource = gameObject.AddComponent<AudioSource>();
    }

    public void RunGeneralSound(AudioClip ac = null)
    {
        if (generalAudioSource == null)
            return;

        generalAudioSource.Stop();
        generalAudioSource.playOnAwake = true;
        generalAudioSource.loop = false;
        generalAudioSource.clip = GeneralSound;
        generalAudioSource.Play();
    }
    #endregion

    #region Hit sound
    public void AddSourceNotifSound()
    {
        if (!haveSound)
            return;

        if (notifAudioSource == null)
            notifAudioSource = gameObject.AddComponent<AudioSource>();
    }

    public void RunPointSound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = PointSound;
        notifAudioSource.Play();
    }

    public void RunPaddleSound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = PaddleSound;
        notifAudioSource.Play();
    }
    #endregion

    public void RunWallSound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = WallSound;
        notifAudioSource.Play();
    }

    public void RunVictorySound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = VictorySound;
        notifAudioSource.Play();
    }
}