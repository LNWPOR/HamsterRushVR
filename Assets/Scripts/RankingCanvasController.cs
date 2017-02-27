using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Linq;
using UnityEngine.UI;

public class RankingCanvasController : MonoBehaviour {

    public GameObject[] ranks;
    private List<PlayerData> playerList;
	// Use this for initialization
	void Start () {
        InitRanking();
    }
	
    private void InitRanking()
    {
        var webAddr = GameManager.Instance.URL + "/api/players/";
        var req = (HttpWebRequest)WebRequest.Create(webAddr);
        req.ContentType = "application/json; charset=utf-8";
        req.Method = "GET";

        var response = (HttpWebResponse)req.GetResponse();
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            JSONObject result = new JSONObject(streamReader.ReadToEnd());

            if (result.GetField("status").ToString().Equals("1"))
            {
                //Debug.Log("GetRank successs");
                //add players to playerList
                playerList = new List<PlayerData>();
                for (int i = 0; i < result.GetField("players").Count; i++)
                {
                    JSONObject player = result.GetField("players")[i];
                    PlayerData playerAdd = new PlayerData(  Converter.JsonToString(player.GetField("_id").ToString()), 
                                                            Converter.JsonToString(player.GetField("name").ToString()),
                                                            Converter.JsonToFloat(player.GetField("scores").ToString()),
                                                            Converter.JsonToFloat(player.GetField("seeds").ToString()));
                    playerList.Add(playerAdd);
                }

                //sort playerList by scores descending
                playerList = playerList.OrderByDescending(o => o.scores).ToList();


                //destroy rank[i] if playerList.Count < ranks.Length
                int countDelete = 0;
                for (int i = playerList.Count; i < ranks.Length; i++)
                {
                    Destroy(ranks[i]);
                    countDelete++;
                }

                //match playerList and UI
                for (int i = 0;i< ranks.Length - countDelete;i++)
                {
                    //scores
                    ranks[i].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = playerList[i].scores.ToString();
                    //seeds    
                    ranks[i].transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = playerList[i].seeds.ToString();
                    //rankNumber
                    ranks[i].transform.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = "Rank " + (i + 1) + "\n"                                                                                                       + playerList[i].name;
                }
            }
            else
            {
                //error
                Debug.Log(result);
            }

        }
    }
}
