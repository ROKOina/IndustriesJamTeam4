using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    string[] rank_names = {"1st","2nd","3rd", "4th", "5th"};
    const int rank_count = RankingData.rank_count;

    TMP_Text[] rank_texts = new TMP_Text[rank_count];
    RankingData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<RankingSystem>().rank_data;

        for(int i = 0; i < rank_count; i++)
        {
            Transform rank_childs = GameObject.Find("RankTexts").transform.GetChild(i);
            rank_texts[i] = rank_childs.GetComponent<TMP_Text>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DispRank();
    }

    void DispRank()
    {
        for(int i = 0; i < rank_count; i++)
        {
            rank_texts[i].text = rank_names[i] + " Name: " + data.name[i] + " Score: " + data.rank[i];
        }
    }

    public void SetRank()
    {
        TMP_InputField inp_fld = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        string name = inp_fld.text;
        int score = (int)AllScore.tokuten;

        for(int i = 0; i < rank_count; i++)
        {
            if(score > data.rank[i])
            {
                string rep_name = data.name[i];
                int rep_rank = data.rank[i];
                data.name[i] = name;
                data.rank[i] = score;
                name = rep_name;
                score = rep_rank;
            }
        }
    }

    public void DelRank()
    {
        for(int i = 0; i < rank_count; i++)
        {
            data.name[i] = "";
            data.rank[i] = 0;
        }
    }
}
