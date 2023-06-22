using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] Button JoinButton;
    [SerializeField] TMP_InputField _nick;
    // Start is called before the first frame update
    void Start()
    {
        JoinButton.onClick.AddListener(OnClickJoinButton);
    }

    private void OnClickJoinButton()
    {
        UserData.Instance.SetUserName(_nick.text);
        SceneManager.LoadScene("02.MainGame");
    }

}
