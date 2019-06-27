using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{

    private float pitch;
    public float offset = 0.3F;

    private Vector3 curpos;
    public float amountToMove = 0.1F;
    public float speed = 1.0F;

    public AudioClip hover;
    public AudioClip click;
    AudioSource audioSource;

    private Vector3 rest;
    private Vector3 hov;

    public Camera mainCam;
    public Camera loadCam;
    public Camera startCam;
    private bool selected;
    private bool onetime1;
    private bool onetime2;

    public GameObject selectHandler;
    MenuHandler count;

    public GameObject cameraFollower;

    // Use this for initialization
    void Start()
    {
        curpos = transform.position;
        hov = transform.position + Vector3.up * amountToMove;
        rest = curpos;
        audioSource = GetComponent<AudioSource>();
        count = (MenuHandler)selectHandler.GetComponent(typeof(MenuHandler));
        selected = false;
        onetime1 = false;
        onetime2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, curpos, speed * Time.deltaTime);

        if (count.GetCount() == 1)
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

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && selected == true && cameraFollower.transform.position == new Vector3(-0.8530005f, -1.715999f, -6.02f))
        {
            OnMouseDown();
        }
    }
    void OnMouseEnter()
    {
        curpos = hov;
        pitch = Random.Range(0.0f, 1.0f);
        Debug.Log(pitch);
        audioSource.pitch = pitch + offset;
        audioSource.PlayOneShot(hover, 1.0F);
    }
    void OnMouseExit() { curpos = rest; }

    private void OnMouseDown()
    {
        mainCam.enabled = false;
        startCam.enabled = false;
        loadCam.enabled = true;
        audioSource.pitch = 1;
        audioSource.PlayOneShot(click, 1.0F);

        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }
}
