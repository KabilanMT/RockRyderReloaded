using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump_Script : MonoBehaviour
{

    private float pitch;
    public float offset = 0.3F;

    public AudioClip hover;
    AudioSource audioSource;

    public GameObject jump;
    private Vector3 curpos;

    private Vector3 rest;
    private Vector3 hov;

    public float amountToMove = 0.1F;
    public float speed = 1.0F;
    private bool selected;
    private bool onetime1;
    private bool onetime2;

    public GameObject cameraFollower;
    public GameObject cameraFollowerObject;
    JumpCameraHandler camera;

    public GameObject selectHandler;
    ShopSelect_Script count;

    // Use this for initialization
    void Start()
    {
        curpos = jump.transform.position;
        hov = jump.transform.position + Vector3.up * amountToMove;
        rest = curpos;
        audioSource = GetComponent<AudioSource>();
        selected = false;
        onetime1 = false;
        onetime2 = true;
        count = (ShopSelect_Script)selectHandler.GetComponent(typeof(ShopSelect_Script));
    }

    // Update is called once per frame
    void Update()
    {
        jump.transform.position = Vector3.MoveTowards(jump.transform.position, curpos, speed * Time.deltaTime);

        /*
        if (!onetime1)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                OnMouseEnter();
                selected = true;
                onetime1 = true;
                onetime2 = false;
            }
        }
        if (!onetime2)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                OnMouseExit();
                selected = false;
                onetime1 = false;
                onetime2 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && selected == true && cameraFollowerObject.transform.position == new Vector3(18.89f, 0.37f, -7.14f))
        {
            OnMouseDown();
        }
        */
    }
    private void OnMouseEnter()
    {
        curpos = hov;

        pitch = Random.Range(0.0f, 1.0f);
        Debug.Log(pitch);
        audioSource.pitch = pitch + offset;
        audioSource.PlayOneShot(hover, 1.0F);
    }
    private void OnMouseExit()
    {
        curpos = rest;
    }
    private void OnMouseDown()
    {
        camera = (JumpCameraHandler)cameraFollower.GetComponent(typeof(JumpCameraHandler));
        camera.startCam();
        count.preshop = false;
        LevelSelect_script.jump = true;
    }
}
