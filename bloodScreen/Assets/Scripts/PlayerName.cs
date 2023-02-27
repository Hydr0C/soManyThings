using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    private string playerName;

    [SerializeField] Text nameText;

    [SerializeField] InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateName(string _newName)
    {

        playerName = inputField.text;
        nameText.text = "Name: " + playerName;
    }
}
