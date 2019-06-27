using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper_Script : MonoBehaviour {
    public float letterPause = 0.1f;
    private bool start;

    private float pitch;
    public float offset = 0.5F;
    public AudioClip talk;
    AudioSource audioSource;

    public GameObject money;
    MoneyHandler payment;

    public GameObject moneyAmt;

    private string apple = "That's an apple. Eat one to increase your launch speed. \nDon't ask me how that works.";
    private string bread = "That's some bread. Eat one to make your boost more \npowerful. Don't ask me how that works.";
    private string steak = "That's a steak. \nI don't own a plate because I'm a duck \nEat one to increase your slipperyness.\nDon't ask me how that works.";
    private string rocket = "That's a rocket engine! \nWhy do I have it? I don't know! \nPlease buy it! (R to boost).";
    private string glider = "That's a glider! \nSomeone bought it for me as a wedding gift ... \n I-I'm not regifting it! I'm just... putting it to good use! \n(G to deploy)";
    private string afford = "You can't afford that! Don't even think about it >:(";
    private string buyFirst = "You can't buy the rocket before \n the glider. It's for... uh... safety?";
    private string max = "I don't think you should eat anymore of that... \nI'm not calling you fat! \nI just think you're not going to benefit from that";
    private string purchase = "Thank you for your purchase!";
    private string nonFoodPurchase = "W-wait what. Why'd you eat it.";
    private string wife = "Please don't bother my wife.";
    private string greeting = "Howdy! I'm the owner of this fine establishment." +
        "\nJust hover over anything you're interested in!";

    // Use this for initialization
    void Start () {
        payment = (MoneyHandler)money.GetComponent(typeof(MoneyHandler));
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        moneyAmt.GetComponent<TextMesh>().text = "Money: " + payment.getMoney();
	}

    public void clear_text()
    {
        StopAllCoroutines();
        GetComponent<TextMesh>().text = "";
    }
    public void set_greeting()
    {
        StopAllCoroutines();
        StartCoroutine(setText(greeting));
    }
    public void set_apple()
    {
        StopAllCoroutines();
        StartCoroutine(setText(apple + "\n" + "Cost: " + payment.getAppleCost() + "\n" + payment.getApplesEaten().ToString() + "/" + payment.getAppleMax()));
    }
    public void set_bread()
    {
        StopAllCoroutines();
        StartCoroutine(setText(bread + "\n" + "Cost: " + payment.getBreadCost() + "\n" + payment.getBreadEaten().ToString() + "/10"));
    }
    public void set_steak()
    {
        StopAllCoroutines();
        StartCoroutine(setText(steak + "\n" + "Cost: " + payment.getSteakCost() + "\n" + payment.getSteaksEaten().ToString() + "/10"));
    }
    public void set_rocket()
    {
        StopAllCoroutines();
        StartCoroutine(setText(rocket + "\n" + "Cost: " + payment.getRocketCost()));
    }
    public void set_glider()
    {
        StopAllCoroutines();
        StartCoroutine(setText(glider + "\n" + "Cost: " + payment.getGliderCost()));
    }
    public void quack()
    {
        StopAllCoroutines();
        StartCoroutine(setText("Quack"));
    }
    public void set_afford()
    {
        StopAllCoroutines();
        StartCoroutine(setText(afford));
    }
    public void set_purchase()
    {
        StopAllCoroutines();
        StartCoroutine(setText(purchase));
    }
    public void set_weird()
    {
        StopAllCoroutines();
        StartCoroutine(setText(nonFoodPurchase));
    }
    public void set_max()
    {
        StopAllCoroutines();
        StartCoroutine(setText(max));
    }
    public void set_wife()
    {
        StopAllCoroutines();
        StartCoroutine(setText(wife));
    }
    public void set_buy_first()
    {
        StopAllCoroutines();
        StartCoroutine(setText(buyFirst));
    }

    IEnumerator setText(string text_to_set)
    {
        pitch = Random.Range(0.0f, 1.5f);
        Debug.Log(pitch);
        audioSource.pitch = pitch + offset;
        audioSource.PlayOneShot(talk, 1.0F);

        GetComponent<TextMesh>().text = "";
        foreach (char letter in text_to_set.ToCharArray())
        {
            GetComponent<TextMesh>().text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
