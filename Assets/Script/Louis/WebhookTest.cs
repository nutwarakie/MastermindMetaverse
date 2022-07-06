using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WebhookTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("Blue");
            StartCoroutine(ChangeToBlue());
        }
        if (Input.GetKeyDown("2"))
        {
            Debug.Log("Red");
            StartCoroutine(ChangeToRed());
        }
        if (Input.GetKeyDown("3"))
        {
            Debug.Log("Green");
            StartCoroutine(ChangeToGreen());
        }
        if (Input.GetKeyDown("4"))
        {
            Debug.Log("Purple");
            StartCoroutine(ChangeToPurple());
        }
    }

    // IEnumerator Upload()
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("myField", "myData");

    //     using (UnityWebRequest www = UnityWebRequest.Post("https://maker.ifttt.com/trigger/L_B/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt", form))
    //     {
    //         yield return www.SendWebRequest();

    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Debug.Log(www.error);
    //         }
    //         else
    //         {
    //             Debug.Log("Form upload complete!");
    //         }
    //     }
    // }

    //Change to Blue light
    public IEnumerator ChangeToBlue(){
        string URL = "https://maker.ifttt.com/trigger/L_B/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator ChangeToRed(){
        string URL = "https://maker.ifttt.com/trigger/L_R/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator ChangeToGreen(){
        string URL = "https://maker.ifttt.com/trigger/L_G/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator ChangeToPurple(){
        string URL = "https://maker.ifttt.com/trigger/L_P/json/with/key/j5USrRaJXmH91nh531q3SeZw-TwNBnXkqmzVJgqqTUt";
        using (UnityWebRequest request = UnityWebRequest.Get(URL)){
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success){
                Debug.Log(request.error);
            }
            else{
                Debug.Log("Form upload complete!");
            }
        }
    }
}