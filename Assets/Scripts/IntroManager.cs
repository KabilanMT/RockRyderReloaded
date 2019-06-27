using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    public AudioClip voiceline1;
    public AudioClip voiceline2;
    public AudioClip voiceline3;
    public AudioClip voiceline4;
    public AudioClip voiceline5;
    public AudioClip voiceline6;

    public AudioClip evilMusic;
    public AudioClip fire;
    public GameObject musicSource;
    public GameObject effectSource;

    AudioSource musicAudio;
    AudioSource effectAudio;
            
    private string subTitle1;
    private string subTitle2;
    private string subTitle3;
    private string subTitle4;
    private string subTitle5;
    private string subTitle6;

    public ArrayList subTitles = new ArrayList();
    public ArrayList audioClips = new ArrayList();

    AudioSource audioSource;

    public GameObject subtitles;
    public GameObject subtitles2;
    public GameObject subtitles3;
    TextMesh subTxt;

    private int index;
    public float letterPause = 0.1F;

    public Material skybox;
    public Light mainLight;

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;

    // Use this for initialization
    void Start () {
        skybox.SetFloat("_Exposure", 1F);
        subTitle1 = "There once lived a rock. \nA rock by the name of Ryder. \nOn a small island in the middle of nowhere, \nthis humble woodsman lived with his wife and child.";
        subTitle2 = "The rock family were happy, with nary a worry. \nThey lived in content at their simple lives.  ";
        subTitle3 = "Then, one day, \nthe infamous paper patrol ruined everything. ";
        subTitle4 = "Bringing ruin to everything and everyone \nthey visit, the paper patrol are a vicious \ngang set on controlling the world. ";
        subTitle5 = "Robbing Ryder of everything he owned, \nthe paper patrol were apparently not \nsatiated. Dead set on breaking the rock, \nthey kidnapped his wife and child. ";
        subTitle6 = "Realizing that he cannot defeat the paper patrol \non his own, Ryder sets out to find the elusive \nScissor Sasquatch to help him rescue his family. ";

        subTitles.Add(subTitle1);
        subTitles.Add(subTitle2);
        subTitles.Add(subTitle3);
        subTitles.Add(subTitle4);
        subTitles.Add(subTitle5);
        subTitles.Add(subTitle6);

        audioClips.Add(voiceline1);
        audioClips.Add(voiceline2);
        audioClips.Add(voiceline3);
        audioClips.Add(voiceline4);
        audioClips.Add(voiceline5);
        audioClips.Add(voiceline6);

        index = 0;
        subTxt = subtitles.GetComponent<TextMesh>();
        audioSource = GetComponent<AudioSource>();
        musicAudio = musicSource.GetComponent<AudioSource>();
        effectAudio = audioSource.GetComponent<AudioSource>();

        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                return;
            }
            else
            {
                if (index == 2)
                {
                    skybox.SetFloat("_Exposure", 0.2F);
                    mainLight.intensity = 0;
                    musicAudio.clip = evilMusic;
                    musicAudio.Play();
                    effectAudio.clip = fire;
                    effectAudio.Play();
                    cam1.enabled = false;
                    cam2.enabled = true;
                    subTxt = subtitles2.GetComponent<TextMesh>();
                }
                if (index == 5)
                {
                    cam2.enabled = false;
                    cam3.enabled = true;
                    subTxt = subtitles3.GetComponent<TextMesh>();
                }
                if (index >= 6)
                {
                    SceneManager.LoadScene("Shop", LoadSceneMode.Single);
                }

                StopAllCoroutines();
                StartCoroutine(setText(subTitles[index].ToString(), subTxt));

                audioSource.Stop();
                audioSource.PlayOneShot((AudioClip) audioClips[index], 1.0F);
                index++;
            }
        }
       
    }
    IEnumerator setText(string text_to_set, TextMesh subText)
    {
        subText.text = "";
        foreach (char letter in text_to_set.ToCharArray())
        {
            subTxt.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
