using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeaderBoard : MonoBehaviour
{

    [SerializeField] CheckpointTimer yourscore;
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    public TMP_InputField NameInput;
    [SerializeField] GameObject Exit;




    private void Awake()
    {

       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        entryContainer = transform.Find("Highscorecontainer");
        entryTemplate = entryContainer.Find("HighscoreTemplate");

 

        /*highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ time = 300, name = "Bob"},
            new HighscoreEntry{ time = 567, name = "Mike"},
            new HighscoreEntry{ time = 900, name = "Jeff"},
            new HighscoreEntry{ time = 234, name = "Garry"},
            new HighscoreEntry{ time = 562, name = "Rob"},
        };*/


        //AddHighscoreEntry(400, "ABC");

        
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        if (PlayerPrefs.HasKey("highscoreTable"))
        {
            Debug.Log("The key " + "highscoreTable" + " exists");
        }
        else
        {
            Debug.Log("The key " + "highscoreTable" + " does not exist");        
            Debug.Log(PlayerPrefs.GetString("highscoreTable"));
            List<HighscoreEntry> highscoreEntryList;
            highscoreEntryList = new List<HighscoreEntry>()
      {
          new HighscoreEntry{ time = 300, name = "Bob"},
          new HighscoreEntry{ time = 567, name = "Mike"},
          new HighscoreEntry{ time = 900, name = "Jeff"},
          new HighscoreEntry{ time = 234, name = "Garry"},
          new HighscoreEntry{ time = 562, name = "Rob"},
      };
      Highscores save = new Highscores { highscoreEntryList = highscoreEntryList };
      string json = JsonUtility.ToJson(save);
      PlayerPrefs.SetString("highscoreTable", json);
      PlayerPrefs.Save();
      Debug.Log(PlayerPrefs.GetString("highscoreTable"));

      jsonString = PlayerPrefs.GetString("highscoreTable");

        }

        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        entryTemplate.gameObject.SetActive(false);



        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].time < highscores.highscoreEntryList[i].time)
                    {
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    
                    }
                }
            }

       if (highscores.highscoreEntryList.Count > 5)
        {
            for (int p = 4; p < highscores.highscoreEntryList.Count; p++)
            {
                highscores.highscoreEntryList.RemoveAt(p);
            }
            
        }
      


        Debug.Log(highscores.highscoreEntryList.Count);


        highscoreEntryTransformList = new List<Transform>();
       
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {

            
                CreateLeaderBoardEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);


            }



            for (int i = 0; i < 10; i++)
        {
         
        }
        
     

        /*Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
      */
    }

    public void AddPlayerInput(){
        string InputName;
        float InputTime;
        InputName = NameInput.text;
        int Besttime = yourscore.scoreTime;
        
       AddHighscoreEntry(Besttime, InputName);
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
       
    }

    public void Returntomenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void CreateLeaderBoardEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 50f;
      
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;

            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }

            entryTransform.Find("Pos").GetComponent<TextMeshProUGUI>().text = rankString;

            float time = highscoreEntry.time;
            int minutes = (int)(time / 60) % 60;
            int seconds = (int)(time % 60);


            entryTransform.Find("Time").GetComponent<TextMeshProUGUI>().text = minutes.ToString() + "m " + seconds.ToString() + "s ";

            string name = highscoreEntry.name;
            entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;

            transformList.Add(entryTransform);
        
    }


    private void AddHighscoreEntry(float time, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { time = time, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }






    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry {
        public float time;
        public string name;
    }

}
