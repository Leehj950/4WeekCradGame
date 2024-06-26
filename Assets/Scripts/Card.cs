using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public bool isflip;
    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontimage;
    bool iscolor;

    AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Setting(int number)
    {
        idx = number;
        frontimage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
    public void OpenCard()
    {
        if (iscolor == false)
        {
            back.GetComponent<SpriteRenderer>().color = Color.gray;
            iscolor = true;
        }
        //텍스트 먼저 닫아준다.
        GameManager.instance.CloseTxt();
        if (GameManager.instance.secondCard != null) { return; }

        audioSource.PlayOneShot(audioClip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        //firstCard가 비었다면
        if (GameManager.instance.firstCard == null)
        {
            //firstCard가 내정보를 넘겨준다.
            GameManager.instance.firstCard = this;
        }
        else
        {
            GameManager.instance.secondCard = this;
            GameManager.instance.Matched();
        }
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.3f);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.3f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

    public void Colorchage()
    {
        back.GetComponent<SpriteRenderer>().color = Color.gray;
    }
}

