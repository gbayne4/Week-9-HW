using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WhoDidIt : MonoBehaviour
{
    TextMeshProUGUI winLose;
    Button Will, Fred, Jake, Leo, Andrew;

    public static string murderer;
    string potentialM;
    // Start is called before the first frame update
    void Start()
    {
        winLose = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Will = transform.GetChild(1).GetComponent<Button>();
        Fred = transform.GetChild(2).GetComponent<Button>();
        Jake = transform.GetChild(3).GetComponent<Button>();
        Leo = transform.GetChild(4).GetComponent<Button>();
        Andrew = transform.GetChild(5).GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        Will.onClick.AddListener(isItWill);
        Fred.onClick.AddListener(isItFred);
        Jake.onClick.AddListener(isItJake);
        Leo.onClick.AddListener(isItLeo);
        Andrew.onClick.AddListener(isItAndrew);


    }

    private void isItWill()
    {
        potentialM = "Will";
        LetsCheck();
    }

    private void isItFred()
    {
        potentialM = "Fred";
        LetsCheck();
    }

    private void isItJake()
    {
        potentialM = "Jake";
        LetsCheck();
    }

    private void isItLeo()
    {
        potentialM = "Leo";
        LetsCheck();
    }

    private void isItAndrew()
    {
        potentialM = "Andrew";
        LetsCheck();
    }

    private void LetsCheck()
    {
        if (potentialM == murderer) { winLose.text = "You won!"; }
        else { winLose.text = "You lost."; }

    }

    /*
    public void WhoDunIt(string murder_npc)
    {
        NPCJsonReceiver npcJSON = JsonUtility.FromJson<NPCJsonReceiver>(murder_npc);
        murderer = npcJSON.murderer_npc;
    }
    */
}
