using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<BrandStoryID> brandStory = new List<BrandStoryID>();
    public List<Quest> quests = new List<Quest>();
    public List<Quest> completedQuests = new List<Quest>();




    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
    void Start()
    {
        LoadTextAsset("Quest");
        brandStory.Add(new BrandStoryID {brandID = 1, name = "SlimeQuest", qip = 0} );
    }

    private void LoadTextAsset(string path) {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');

        for (int i = 1; i < lines.Length; i++) {
            string[] col = lines[i].Split('\t');

            Quest tempQuest = new Quest();
            tempQuest.storyID = int.Parse(col[0]);
            tempQuest.qip = int.Parse(col[1]);
            tempQuest.name = col[2];
            tempQuest.description = col[3];
            tempQuest.xpReward = int.Parse(col[4]);
            tempQuest.goldReward = int.Parse(col[5]);
            tempQuest.require = int.Parse(col[6]);

            quests.Add(tempQuest);
        }
    }

    public Quest GetQuest(int id)
    {
        var qip = GetQipStory(id);
        var getQ = quests.FirstOrDefault(x => x.storyID == id && x.qip == qip);
        if (getQ != null)
        {
            return getQ;
        }
        else
        {
            return null;
        }
    }

    public int GetQipStory(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            return getQip.qip;
        }
        else
        {
            return 0;
        }
    }

    public void SetQipStory(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            getQip.qip++; //tiến trình + 1
        }
    }

    public void BackQip(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            getQip.qip--; //tiến trình - 1
        }
    }

}

[System.Serializable]
public class BrandStoryID
{
    public int brandID;
    public string name;
    public int qip; //quest in progress
}

[System.Serializable]
public class Quest
{
    public int storyID;
    public int qip;
    public string name;
    public string description;
    public int xpReward;
    public int goldReward;
    public int require;
    public int current;
    public bool complete;

    public void SetCurrent()
    {
        current++;
        if (current >= require)
        {
            complete = true;
        }
    }
}
