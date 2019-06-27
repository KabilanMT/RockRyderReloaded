using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider_Script : MonoBehaviour
{

    private float pitch;
    public float offset = 0.3F;

    public AudioClip hover;
    AudioSource audioSource;

    public GameObject glider;
    private Vector3 curpos;

    private Vector3 rest;
    private Vector3 hov;

    public float amountToMove = 0.1F;
    public float speed = 1.0F;

    public GameObject shopkeeper;
    Shopkeeper_Script textHandler;

    public AudioClip chomp;
    public GameObject money;
    MoneyHandler payment;

    public GameObject selectHandler;
    ShopSelect_Script count;
    private bool onetime1;
    private bool onetime2;
    private bool selected;

    public GameObject cameraFollower;

    // Use this for initialization
    void Start()
    {
        curpos = glider.transform.position;
        hov = glider.transform.position + Vector3.up * amountToMove;
        rest = curpos;
        audioSource = GetComponent<AudioSource>();
        textHandler = (Shopkeeper_Script)shopkeeper.GetComponent(typeof(Shopkeeper_Script));
        count = (ShopSelect_Script)selectHandler.GetComponent(typeof(ShopSelect_Script));
        onetime1 = false;
        onetime2 = false;
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (count.GetCount() == 5)
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

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && selected == true && cameraFollower.transform.position == new Vector3(0.7979998f, 3.1f, -6.161f))
        {
            OnMouseDown();
        }

        glider.transform.position = Vector3.MoveTowards(glider.transform.position, curpos, speed * Time.deltaTime);
    }
    private void OnMouseEnter()
    {
        textHandler.set_glider();
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
        payment = (MoneyHandler)money.GetComponent(typeof(MoneyHandler));
        if (payment.getMoney() < payment.getGliderCost())
        {
            pitch = Random.Range(0.0f, 1.0f);
            Debug.Log(pitch);
            audioSource.pitch = pitch + offset;
            audioSource.PlayOneShot(hover, 1.0F);
            textHandler.set_afford();
        }
        else
        {
            audioSource.pitch = 1;
            audioSource.PlayOneShot(chomp, 1.0F);
            textHandler.set_weird();
            payment.buyGlider();
            payment.subMoney(payment.getGliderCost());
            Destroy(glider);
            Destroy(this);
        }
    }
}
