using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    public Quest quest;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI requiment;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI exp;
    public int brandID;


    public void ShowQuest(Quest q, int id)
    {
        quest = q;
        title.text = quest.name;
        description.text = quest.description;
        requiment.text = quest.require.ToString();
        gold.text = quest.goldReward.ToString();
        exp.text = quest.xpReward.ToString();
        brandID = id;
    }

    public void AcceptBtn() {
        // Accept the quest
        QuestManager.instance.completedQuests.Add(quest);
        gameObject.SetActive(false);
    }

    public void CancelBtn() {
        // Cancel the quest
        QuestManager.instance.BackQip(brandID);
        gameObject.SetActive(false);
    }
}
