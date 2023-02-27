using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Class : MonoBehaviour
{
    [SerializeField] private Text classText;
    [SerializeField] private Image classImage;
    [SerializeField] private List<string> classes = new List<string>();
    [SerializeField] private Dropdown classDrop;

    // Start is called before the first frame update
    void Start()
    {
        classes.Add("Paladin");
        classes.Add("Barbarian");
        classes.Add("Wizard");
        classes.Add("Gun");
        classes.Add("Rogue");

        classText.text = classDrop.options[classDrop.value].text;
        classImage.sprite = classDrop.options[classDrop.value].image;
    }

    // Update is called once per frame
    public void UpdateClass()
    {
        classText.text = classDrop.options[classDrop.value].text;
        classImage.sprite = classDrop.options[classDrop.value].image;

    }
}
