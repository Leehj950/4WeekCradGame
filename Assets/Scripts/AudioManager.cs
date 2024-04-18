using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;    

    AudioSource audioSource;
    AudioSource audioSourceSuccess;
    AudioSource audioSourceFailed;
    AudioSource audioSourceEnd;

    public AudioClip audioClip;
    public AudioClip successSound;
    public AudioClip failureSound;
    public AudioClip endSound;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = this.audioClip;
        audioSource.Play();

        // ���� ������ ���ҽ��� �������� ���� �ǹ��Ѵ�.
        audioSourceSuccess = GetComponent<AudioSource>();

        // ���� ������ ���ҽ��� �������� ���� �ǹ��Ѵ�.
        audioSourceFailed = GetComponent<AudioSource>();
     
        // �� ������ ���ҽ��� �������� ���� �ǹ��Ѵ�.
        audioSourceEnd = GetComponent<AudioSource>();  
    }

    // ���������� �ѹ��� ����ϱ�����
    public void SuccessSoundPlay()
    {
        audioSourceSuccess.PlayOneShot(successSound);
    }

    public void FailureSoundPlay() 
    {
        audioSourceFailed.PlayOneShot(failureSound);
    }

    public void EndSoundPlay()
    {
        audioSourceEnd.PlayOneShot(endSound);
    }
    public void SoundPause()
    {
        audioSource.Pause();
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
