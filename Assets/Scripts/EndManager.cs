using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour {
    //Ryder finally found them, the paper patrol. Springing into action, the Scissor Sasquatch fell each patrol member quickly and efficiently. 
    // Rushing over quickly, Ryder and the Scissor Sasquatch grabs the Rock family and heads for home.
    // With the paper patrol defeated, and Ryder's family rescued, everyone can finally relax and return to the life they once had. 
    // The scissor Sasquatch was also offered to live with the Ryder's. Given an option other than isolation, the Sasquatch is warmly welcomed amongst the Ryders.
    //Congratulations on finishing the game! Thank you for playing! Made by: Dylan Chew, Gagan Heer, Renzo Pampalona, Kabilan Thangarajah. Music by Louie Zong.

    public AudioClip voiceline1;
    public AudioClip voiceline2;
    public AudioClip voiceline3;
    public AudioClip voiceline4;
    public AudioClip voiceline5;

    public AudioClip goodMusic;
    public AudioClip gun;
    public GameObject musicSource;
    public GameObject miscSource;
    AudioSource musicAudio;
    AudioSource miscAudio;

    private string subTitle1;
    private string subTitle2;
    private string subTitle3;
    private string subTitle4;
    private string subTitle5;

    public ArrayList subTitles = new ArrayList();
    public ArrayList audioClips = new ArrayList();

    AudioSource audioSource;

    public GameObject subtitles;
    public GameObject subtitles2;
    public GameObject subtitles3;
    TextMesh subTxt;

    private int index;
    public float letterPause = 0.1F;

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;

    // Use this for initialization
    void Start () {
        subTitle1 = "Ryder finally found them, the paper patrol. \nSpringing into action, the Scissor Sasquatch \nfell each patrol member quickly and efficiently";
        subTitle2 = "Rushing over quickly, Ryder and the Scissor \nSasquatch grabs the Rock family and heads for home.";
        subTitle3 = "With the paper patrol defeated, and \nRyder's family rescued, everyone can finally \nrelax and return to the life they once had.";
        subTitle4 = "The scissor Sasquatch was also offered to \nlive with the Ryder's. Given an option \nother than isolation, the Sasquatch is \nwarmly welcomed amongst the Ryders.";
        subTitle5 = "Congratulations on finishing the game! \nThank you for playing! \nMade by: Dylan Chew, \nGagan Heer, \nRenzo Pampalona, \nKabilan Thangarajah. \nMusic by Louie Zong.";

        subTitles.Add(subTitle1);
        subTitles.Add(subTitle2);
        subTitles.Add(subTitle3);
        subTitles.Add(subTitle4);
        subTitles.Add(subTitle5);

        audioClips.Add(voiceline1);
        audioClips.Add(voiceline2);
        audioClips.Add(voiceline3);
        audioClips.Add(voiceline4);
        audioClips.Add(voiceline5);

        index = 0;
        subTxt = subtitles.GetComponent<TextMesh>();
        audioSource = GetComponent<AudioSource>();
        musicAudio = musicSource.GetComponent<AudioSource>();
        miscAudio = miscSource.GetComponent<AudioSource>();

        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                return;
            }
            else
            {
               if (index == 1)
               {
                    cam1.enabled = false;
                    cam2.enabled = true;
                    miscAudio.PlayOneShot(gun, 1.0F);
                    subTxt = subtitles2.GetComponent<TextMesh>();
               }
               if (index == 2)
                {
                    cam2.enabled = false;
                    cam3.enabled = true;
                    subTxt = subtitles3.GetComponent<TextMesh>();
                    musicAudio.clip = goodMusic;
                    musicAudio.Play();
                }
               if (index >= 5)
                {
                    SceneManager.LoadScene("Shop", LoadSceneMode.Single);
                }

                StopAllCoroutines();
                StartCoroutine(setText(subTitles[index].ToString(), subTxt));

                audioSource.Stop();
                audioSource.PlayOneShot((AudioClip)audioClips[index], 1.0F);
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
