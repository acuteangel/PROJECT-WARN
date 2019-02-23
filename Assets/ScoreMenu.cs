using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class ScoreMenu : MonoBehaviour
{
    private string highscore_url = "https://project-warn.herokuapp.com/api/leaderboard";
    //    public int id;
    public InputField player;
    public Text text;

    private int level;
    //    public string createdAt;
    //   public string updatedAt;

    private void Start()
    {
        level = GameManager.instance.level;
        GameManager.instance.gameObject.SetActive(false);
        text.text = "You died on floor " + level;
    }

    public void Post()
    {
        StartCoroutine(Upload());
    }
    IEnumerator Upload()
    {

        WWWForm form = new WWWForm();
        
        form.AddField("player", player.text);

        form.AddField("score", level);

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
        Reset();
    }

    public void Reset()
    {
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene(0);
    }
}