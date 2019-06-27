using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiddleManager : MonoBehaviour {
    //After days of travel, Ryder has finally found the Scissor Sasquatch. 
    //Pleading his case, the scissor Sasquatch agrees to help Ryder unconditionally.
    //Now paired up, the two continue onwards to the paper zone in search of Ryders family. 

    public AudioClip voiceline1;
    public AudioClip voiceline2;
    public AudioClip voiceline3;

    private string subTitle1;
    private string subTitle2;
    private string subTitle3;

    public ArrayList subTitles = new ArrayList();
    public ArrayList audioClips = new ArrayList();

    AudioSource audioSource;
    public GameObject subtitles;
    public GameObject subtitles2;
    TextMesh subTxt;

    private int index;
    public float letterPause = 0.1F;

    public Camera cam1;
    public Camera cam2;

    // Use this for initialization
    void Start () {
        subTitle1 = "After days of travel, \nRyder has finally found \nthe Scissor Sasquatch. ";
        subTitle2 = "Pleading his case, the \nScissor Sasquatch agrees \nto help Ryder unconditionally.";
        subTitle3 = "Now paired up, the two continue \nonwards to the paper \nzone in search of \nRyder's family.";

        subTitles.Add(subTitle1);
        subTitles.Add(subTitle2);
        subTitles.Add(subTitle3);

        audioClips.Add(voiceline1);
        audioClips.Add(voiceline2);
        audioClips.Add(voiceline3);

        index = 0;
        subTxt = subtitles.GetComponent<TextMesh>();
        audioSource = GetComponent<AudioSource>();

        cam1.enabled = true;
        cam2.enabled = false;
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
                if (index == 2)
                {
                    cam1.enabled = false;
                    cam2.enabled = true;
                    subTxt = subtitles2.GetComponent<TextMesh>();
                }
                if (index >= 3)
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
