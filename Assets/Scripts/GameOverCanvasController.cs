using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net;

public class GameOverCanvasController : MonoBehaviour {

    public GameObject player;
    public Text scoresText;
    public Text seedsText;
    void Awake()
    {
        scoresText.text = player.GetComponent<PlayerScoreController>().playerCurrentScore.ToString();
        seedsText.text = player.GetComponent<PlayerSeedController>().playerCurrentMaxSeed.ToString();
        AddScoreSeed();
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    private void AddScoreSeed()
    {
        var webAddr = GameManager.Instance.URL + "/api/players/" + GameManager.Instance.playerData.id;
        var req = (HttpWebRequest)WebRequest.Create(webAddr);
        req.ContentType = "application/json; charset=utf-8";
        req.Method = "PUT";

        using (var streamWriter = new StreamWriter(req.GetRequestStream()))
        {
            JSONObject data = new JSONObject();
            data.AddField("scores", scoresText.text);
            data.AddField("seeds", seedsText.text);
            streamWriter.Write(data.ToString());
            streamWriter.Flush();
        }

        var response = (HttpWebResponse)req.GetResponse();
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            JSONObject result = new JSONObject(streamReader.ReadToEnd());
            if (result.GetField("status").ToString().Equals("1"))
            {
                //Debug.Log("collect score success");
                //Debug.Log(result);
            }
            else
            {
                //error
                Debug.Log(result);
            }

        }
    }
}
