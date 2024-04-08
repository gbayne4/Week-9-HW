using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ChatGPTWrapper;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    ChatGPTConversation chatGPT;

    [SerializeField]
    TMP_InputField if_PlayerTalk;
    [SerializeField]
    TextMeshProUGUI tx_AIReply;
   

    string playerName = "Human";

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        chatGPT.Init();
    }

    private void Start()
    {
        chatGPT.SendToChatGPT("{\"player_said\":"+"\"Hello, I am a detective investigating the murder of Sam, please give me your name and information.\"}");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Submit"))
        {
            SubmitChatMessage();
        }
    }

    //Callback from ai
    public void ReceiveChatGPTReply(string message) //keeping things bug free
    {
        try
        {
            if (!message.EndsWith("}")) //Ai messed stuff up
            {
                if (message.Contains("}"))
                {
                    message = message.Substring(0, message.LastIndexOf("}") + 1);
                }
                else
                {
                    message += "}";
                }
            }
            message = message.Replace("\\", "\\\\");
            NPCJsonReceiver npcJSON = JsonUtility.FromJson<NPCJsonReceiver>(message);
            string talkLine = npcJSON.reply_to_player;
            WhoDidIt.murderer = npcJSON.murderer_npc;
            tx_AIReply.text = talkLine;
            //npc.ShowAnimation(npcJSON.animation_name); //gives the animation she wants to play
        }
        catch(System.Exception e) 
        {
            Debug.Log(e.Message);
            string talkLine = "Don't say that!";
        }


    }

    public void SubmitChatMessage() 
    {
        Debug.Log("Message sent: " + if_PlayerTalk);
        chatGPT.SendToChatGPT("{\"player_said\":\"" + if_PlayerTalk.text + "\"}");
        ClearText();
    }

    void ClearText()
    {
        if_PlayerTalk.text = "";
    }
}
