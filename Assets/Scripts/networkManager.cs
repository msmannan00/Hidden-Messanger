using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;
using System.Net;

public class networkManager
{

    /*shared instances*/
    static networkManager manager = new networkManager();

    public static networkManager sharedInstance()
    {
        return manager;
    }

    public void sendMessage(string name,string message,string relativeName,string mobid)
    {
        Thread thread = new Thread(() => sendMessageAsync(name, message, relativeName,mobid));
        thread.Start();
    }

    public void sendMessageAsync(string name, string message, string relativeName,string mobid)
    {
        Regex rgx = new Regex("[^a-zA-Z0-9 -]");
        name = rgx.Replace(name, "");
        message = rgx.Replace(message, "");

        if (name.Length > 100)
        {
            name = name.Substring(0, 100);
        }

        if (message.Length > 100)
        {
            message = message.Substring(0, 100);
        }


        string urlAddress = "https://boogle.store/dead?mobid=" + mobid + "&name=" + name + "_" + relativeName + "&message=" + message;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log("message send");
            response.Close();
        }


    }

}
