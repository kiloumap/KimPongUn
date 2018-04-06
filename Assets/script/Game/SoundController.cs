using UnityEngine;
using System.Collections;

/// <summary>
/// Music is essential for a good game
/// </summary>
public class SoundController : MonoBehaviour {
    public bool haveSound           = true;                 // For desable sound 

    [Header("General Sounds")]                              // Part "general"
    public AudioClip GeneralSound   = null;

    [Header("Ball Sounds")]                                 // Specific sound
    public AudioClip WallSound      = null;
    public AudioClip PaddleSound    = null;
    public AudioClip VictorySound   = null;
    public AudioClip PointSound     = null;

    AudioSource generalAudioSource  = null;
    AudioSource notifAudioSource    = null;

    void Start ()
    {
        AddAudioSourceAndPlayGeneralSound();
    }
    #region General Sound & config source

    /// <summary>
    /// Create first source and play general sound
    /// </summary>
    public void AddAudioSourceAndPlayGeneralSound()
    {
        if (!haveSound)
            return;

        AddAudioSource();
        RunGeneralSound(GeneralSound);
    }

    /// <summary>
    /// Adding general source sound
    /// </summary>
    public void AddAudioSource()
    {
        if (generalAudioSource == null)
            generalAudioSource = gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// And now running
    /// </summary>
    /// <param name="ac"></param>
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

    /// <summary>
    /// Notification => when ball hit a wall or ball
    /// </summary>
    #region Hit sound
    public void AddSourceNotifSound()
    {
        if (!haveSound)
            return;

        if (notifAudioSource == null)
            notifAudioSource = gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// Sound for a point
    /// </summary>
    public void RunPointSound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = PointSound;
        notifAudioSource.Play();
    }


    /// <summary>
    /// When ball hit paddle
    /// </summary>
    public void RunPaddleSound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = PaddleSound;
        notifAudioSource.Play();
    }
    #endregion

    /// <summary>
    /// Or a wall from north of south
    /// </summary>
    public void RunWallSound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = WallSound;
        notifAudioSource.Play();
    }

    /// <summary>
    /// Now the victryyy
    /// </summary>
    public void RunVictorySound()
    {
        if (notifAudioSource == null)
            AddSourceNotifSound();

        notifAudioSource.clip = VictorySound;
        notifAudioSource.Play();
    }
}