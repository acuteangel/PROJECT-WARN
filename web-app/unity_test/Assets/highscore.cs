using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class highscore : MonoBehaviour
{
    private string highscore_url = "http://localhost:3001/api/post";
    public string player;
    public string score;

   public void Post() {
        StartCoroutine(Upload());
    }
    IEnumerator Upload() {

        WWWForm form = new WWWForm();

        form.AddField( "player", player );

        form.AddField( "score", score );

        UnityWebRequest www = UnityWebRequest.Post(highscore_url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            print(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}