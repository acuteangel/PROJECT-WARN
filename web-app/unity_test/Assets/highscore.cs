using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class highscore : MonoBehaviour
{
    string highscore_url = "http://localhost:3000";
    string playName = "Player1";
    int score = -1;

    // Use this for initialization
    IEnumerator Start()
    {
        // Create a form object for sending high score data to the server
        WWWForm form = new WWWForm();

        // Assuming the perl script manages high scores for different games
        form.AddField( "game", "MyGameName" );

        // The name of the player submitting the scores
        form.AddField( "playerName", playName );

        // The score
        form.AddField( "score", score );

        // Create a download object
        var download = UnityWebRequest.Post(highscore_url, form);

        // Wait until the download is done
        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
        {
            print( "Error downloading: " + download.error );
        }
        else
        {
            // show the highscores
            Debug.Log(download.downloadHandler.text);
        }
    }
}