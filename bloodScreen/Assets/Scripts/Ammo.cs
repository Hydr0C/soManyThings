using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    private int ammoCount;

    private int ammoA;
    private int ammoB;
    private int ammoC;

    [SerializeField] Text ammoText;
    [SerializeField] InputField ammoInput;

    delegate void AmmoPickUpDelegate();
    AmmoPickUpDelegate AmmoPickUp;

    // Start is called before the first frame update
    void Start()
    {
        AmmoPickUp += GetAmmoA;
        AmmoPickUp += GetAmmoB;
        AmmoPickUp += GetAmmoC;

        ammoCount = 400000;
        ammoText.text = "Current Ammo: " + ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AmmoPickUp();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            AmmoPickUp -= GetAmmoA;
        }
    }

    public void ReduceAmmo()
    {
        ammoCount -= 10;
        ammoText.text = "Current Ammo: " + ammoCount;
    }

    public void IncreaseAmmo()
    {
        ammoCount += int.Parse(ammoInput.text);
        ammoText.text = "Current Ammo: " + ammoCount;
    }

    public void GetAmmoA()
    {
        ammoA++;
        Debug.Log("ammo a git got");
    }
    public void GetAmmoB()
    {
        ammoB++;
        Debug.Log("ammo b got gitten");
    }
    public void GetAmmoC()
    {
        ammoC++;
        Debug.Log("ammo c git got gitted");
    }
}
