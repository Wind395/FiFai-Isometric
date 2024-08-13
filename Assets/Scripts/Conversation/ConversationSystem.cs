using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Latina
{
    public class ConversationSystem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] GameObject Player;
        [SerializeField] GameObject NPC;
        [SerializeField] TextMeshProUGUI contentText;
        [SerializeField] GameObject board;
        public List<ConversationBase> ListAllConversations = new List<ConversationBase>();
        public int curentCount;
        public QuestPanel questPanel;
        public int brandStoryID; // nhánh truyện

        void Start()
        {
            contentText.text = ListAllConversations[curentCount].content;
            Player.SetActive(true);
        }

        public void loadTextAll(string path)
        {
            TextAsset loadText = Resources.Load<TextAsset>(path);
            if (loadText != null)
            {
                string[] lines = loadText.text.Split('\n');
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] cols = lines[i].Split("\t");

                    ConversationBase baseConversations = new ConversationBase();
                    baseConversations.id = int.Parse(cols[0]);
                    baseConversations.name = cols[1];
                    baseConversations.content = cols[2];
                    ListAllConversations.Add(baseConversations);
                }
            }
            else
            {
                Debug.Log("No text");
            }
            curentCount = 0;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            DialogueSystem();
            curentCount++;
        }

        public void DialogueSystem()
        {
            if (curentCount < ListAllConversations.Count)
            {
                if (ListAllConversations[curentCount].name == "Player")
                {
                    Player.SetActive(true);
                    NPC.SetActive(false);
                }
                else
                {
                    Player.SetActive(false);
                    NPC.SetActive(true);
                }
                contentText.text = ListAllConversations[curentCount].content;
            }
            else
            {
                Debug.Log("No more conversations");
                QuestManager.instance.SetQipStory(brandStoryID); // tăng lên 1
                Debug.Log("Fuck1");

                var getQ = QuestManager.instance.GetQuest(brandStoryID);
                Debug.Log("Quest retrieved: " + (getQ != null ? "Not null" : "Null"));
                Debug.Log("Fuck2");

                if (getQ != null)
                {
                    Debug.Log("Fuck3");
                    questPanel.ShowQuest(getQ, brandStoryID);
                    Debug.Log("Fuck4");
                    questPanel.gameObject.SetActive(true);
                    Debug.Log("Fuck5");
                }
                else
                {
                    Debug.Log("Fuck6");
                }

                gameObject.SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class ConversationBase
    {
        public int id;
        public string name;
        public string content;
    }
}
