using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paper_Hover : MonoBehaviour
{

    private float pitch;
    public float offset = 0.3F;

    public AudioClip hover;
    AudioSource audioSource;

    public GameObject sign;
    private Vector3 curpos;

    private Vector3 rest;
    private Vector3 hov;

    public float amountToMove = 0.1F;
    public float speed = 1.0F;

    public GameObject levelHandler;
    LevelHandler lvlhandler;

    private bool onetime1;
    private bool onetime2;
    private bool selected;

    public GameObject cameraFollower;

    // Use this for initialization
    void Start()
    {
        curpos = sign.transform.position;
        hov = sign.transform.position + Vector3.up * amountToMove;
        rest = curpos;
        audioSource = GetComponent<AudioSource>();
        onetime1 = false;
        onetime2 = false;
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelSelect_script.GetCount() == 2)
        {
            if (!onetime1)
            {
                OnMouseEnter();
                onetime1 = true;
                onetime2 = false;
                selected = true;
            }
        }
        else
        {
            if (!onetime2)
            {
                OnMouseExit();
                onetime1 = false;
                onetime2 = true;
                selected = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && selected == true && cameraFollower.transform.position == new Vector3(20.711f, 1.533003f, -5.278993f))
        {
            OnMouseDown();
        }

        sign.transform.position = Vector3.MoveTowards(sign.transform.position, curpos, speed * Time.deltaTime);
    }

    private void OnMouseEnter()
    {
        if (PlayerPrefs.GetInt("paper") == 1)
        {
            curpos = hov;

            pitch = Random.Range(0.0f, 1.0f);
            Debug.Log(pitch);
            audioSource.pitch = pitch + offset;
            audioSource.PlayOneShot(hover, 1.0F);

            lvlhandler = (LevelHandler)levelHandler.GetComponent(typeof(LevelHandler));
            lvlhandler.setPaperScore();
        }
        else
        {
            lvlhandler = (LevelHandler)levelHandler.GetComponent(typeof(LevelHandler));
            lvlhandler.setNotUnlocked();
        }
    }
    private void OnMouseExit()
    {
        curpos = rest;
    }
    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("paper") == 1)
        {
            SceneManager.LoadScene("level3", LoadSceneMode.Single);
        }
    }
}
