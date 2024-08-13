using System.Collections;
using System.Collections.Generic;
using Latina;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour
{
    public Transform Player;
    public ConversationSystem Conversation;
    public int brandid = 1;

    private void Start() {
        brandid = 1;
    }
    private void OnMouseDown() {
        if(Vector2.Distance(transform.position, Player.transform.position) < 0.5f)
        {
            int qip = QuestManager.instance.GetQipStory(brandid);
            switch (qip)
            {
                case 0:
                    {
                        Conversation.gameObject.SetActive(true);
                        Conversation.loadTextAll("Conversation");
                        Conversation.brandStoryID = brandid;
                        Conversation.DialogueSystem();
                    }
                    break;

                case 1:
                    {
                        Conversation.gameObject.SetActive(true);
                        Conversation.loadTextAll("fox2");
                        Conversation.brandStoryID = 0; //Không thay đổi tiến trình, chỉ thay đổi khi làm nhiệm vụ
                        Conversation.DialogueSystem();
                    }
                    break;
                case 2:
                    {
                        Conversation.gameObject.SetActive(true);
                        Conversation.loadTextAll("fox3");
                        Conversation.brandStoryID = brandid;
                        Conversation.DialogueSystem();
                    }
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
