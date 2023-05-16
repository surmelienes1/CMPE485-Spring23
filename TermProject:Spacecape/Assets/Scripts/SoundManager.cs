using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    static public bool muted = false;
    public AudioSource m_MyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = FindObjectOfType<AudioSource>();
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        UpdateButtonIcon();
        m_MyAudioSource.Play();
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            m_MyAudioSource.mute = true;

        }
        else
        {
            muted = false;
            m_MyAudioSource.mute = false;

        }
        Save();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}