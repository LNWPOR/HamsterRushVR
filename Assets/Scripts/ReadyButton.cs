using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyButton : MonoBehaviour {

	public Text playerName;

    public void OnClickReady()
    {
        //Debug.Log(playerName.text);

        var webAddr = GameManager.Instance.URL + "/api/players";
        var req = (HttpWebRequest)WebRequest.Create(webAddr);
        req.ContentType = "application/json; charset=utf-8";
        req.Method = "POST";

        using (var streamWriter = new StreamWriter(req.GetRequestStream()))
        {
            JSONObject data = new JSONObject();
            data.AddField("name",playerName.text);
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
                string id = result.GetField("player").GetField("_id").ToString();
                string name = result.GetField("player").GetField("name").ToString();
                GameManager.Instance.playerData = new PlayerData(id, name);
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
