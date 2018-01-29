using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    public GameObject flashlight;
    public GameObject lightObj;
    public float maxEnergy;
    private float currentEnergy;
    private bool flashlightEnabled;

    private int batteries;
    private GameObject batteryPickedUp;
    private float usedEnergy;

	public void Start ()
    {
        currentEnergy = maxEnergy;
        maxEnergy = 50 * batteries;
	}
	
	public void FixedUpdate ()
    {
        maxEnergy = 50 * batteries;
        currentEnergy = maxEnergy;

        //equip
        if (Input.GetKeyDown(KeyCode.F))
            flashlightEnabled =! flashlightEnabled;

        if (flashlightEnabled)
        {
            flashlight.SetActive(true);

            if (currentEnergy <= 0)
            {
                lightObj.SetActive(false);
                batteries = 0;
            }
            if (currentEnergy > 0)
            {
                lightObj.SetActive(true);
                currentEnergy -= 0.5f * Time.deltaTime;
                usedEnergy += 10f * Time.deltaTime;
            }

            if (usedEnergy >= 50)
            {
                batteries -= 1;
                usedEnergy = 0;
            }

        }
        else
        {
            flashlight.SetActive(false);
        }

        print("Batteries:" + batteries);
        print("usedEnergy:" + usedEnergy);
	}
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Battery")
        {
            batteryPickedUp = other.gameObject;
            batteries += 1;
            Destroy(batteryPickedUp);
        }
    }
}
