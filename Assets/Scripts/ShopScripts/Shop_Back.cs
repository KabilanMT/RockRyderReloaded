using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Back : MonoBehaviour
{

    private float pitch;
    public float offset = 0.3F;

    public AudioClip hover;
    AudioSource audioSource;

    public GameObject shop;
    private Vector3 curpos;

    private Vector3 rest;
    private Vector3 hov;

    public float amountToMove = 0.1F;
    public float speed = 1.0F;

    public GameObject cameraFollower;
    public GameObject cameraFollowerObject;
    MainCameraHandler camera;

    public GameObject selectHandler;
    ShopSelect_Script count;
    private bool onetime1;
    private bool onetime2;
    private bool selected;


    // Use this for initialization
    void Start()
    {
        curpos = shop.transform.position;
        hov = shop.transform.position + Vector3.up * amountToMove;
        rest = curpos;
        audioSource = GetComponent<AudioSource>();
        count = (ShopSelect_Script)selectHandler.GetComponent(typeof(ShopSelect_Script));
        onetime1 = false;
        onetime2 = false;
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (count.GetCount() == 0)
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

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && selected == true && cameraFollowerObject.transform.position == new Vector3(0.7979998f, 3.1f, -6.161f))
        {
            OnMouseDown();
        }

        shop.transform.position = Vector3.MoveTowards(shop.transform.position, curpos, speed * Time.deltaTime);
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
        camera = (MainCameraHandler)cameraFollower.GetComponent(typeof(MainCameraHandler));
        camera.returnCam();
        count.preshop = true;
    }
}
