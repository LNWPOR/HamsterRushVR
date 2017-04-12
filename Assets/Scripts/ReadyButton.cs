using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReadyButton : MonoBehaviour {

	public TextMeshProUGUI playerName;
    public void OnClickReady()
    {
        if (!((int)playerName.text[0]).Equals(8203))
        {
            var webAddr = GameManager.Instance.URL + "/api/players";
            var req = (HttpWebRequest)WebRequest.Create(webAddr);
            req.ContentType = "application/json; charset=utf-8";
            req.Method = "POST";

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                JSONObject data = new JSONObject();
                data.AddField("name", playerName.text);
                streamWriter.Write(data.ToString());
                streamWriter.Flush();
            }

            var response = (HttpWebResponse)req.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                JSONObject result = new JSONObject(streamReader.ReadToEnd());
                if (result.GetField("status").ToString().Equals("1"))
                {
                    //Debug.Log("Sign in success.");
                    string id = Converter.JsonToString(result.GetField("player").GetField("_id").ToString());
                    string name = Converter.JsonToString(result.GetField("player").GetField("name").ToString());
                    float scores = Converter.JsonToFloat(result.GetField("player").GetField("scores").ToString());
                    float seeds = Converter.JsonToFloat(result.GetField("player").GetField("seeds").ToString());
                    GameManager.Instance.playerData = new PlayerData(id, name, scores, seeds);
                    SceneManager.LoadScene("Menu");
                }
                else
                {
                    //error
                    Debug.Log(result);
                }

            }
        }
    }
}
