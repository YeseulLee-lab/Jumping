using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData Instance { get { return _instance; } }
    public static UserData _instance;

    private string userName;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    public void SetUserName(string name)
    {
        userName = name;
    }

    public string GerUserName()
    {
        return userName;
    }
}
