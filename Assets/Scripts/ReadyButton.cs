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
            string json = "{\"name\":\"" + playerName.text + "\"}";
            streamWriter.Write(json);
            streamWriter.Flush();
        }

        var response = (HttpWebResponse)req.GetResponse();
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            if (result.ToString().Equals("1"))
            {
                //Debug.Log("Sign in success.");
                GameManager.Instance.playerData = new PlayerData(playerName.text);
                SceneManager.LoadScene("Menu");
            }
            else if(result.ToString().Equals("0"))
            {
                Debug.Log("Already have Player with this name. Please use other name.");
            }
            
        }
    }
}
