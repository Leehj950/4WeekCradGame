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

        // 성공 사운드의 리소스를 가져오는 것을 의미한다.
        audioSourceSuccess = GetComponent<AudioSource>();

        // 실패 사운드의 리소스를 가져오는 것을 의미한다.
        audioSourceFailed = GetComponent<AudioSource>();
     
        // 끝 사운드의 리소스를 가져오는 것을 의미한다.
        audioSourceEnd = GetComponent<AudioSource>();  
    }

    // 성공했을때 한번만 출력하기위한
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
