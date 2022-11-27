using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarSwitcher : MonoBehaviour
{
    public GameObject nextButtons;
    public GameObject cars;
    public Material mesh;
  

  
    private void Awake()
    {
        nextButtons.SetActive(false);
       
    }
    public void ShowNextButton()
    {
        if (!nextButtons.activeInHierarchy)
        {
            nextButtons.SetActive(true);
        }
        else
        {
            nextButtons.SetActive(false);
        }

    }

    public void NextCar()
    {
        for (int i = 0; i < cars.transform.childCount; i++)
        {
            if (cars.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                if (i == cars.transform.childCount - 1)
                {
                    cars.transform.GetChild(i).gameObject.SetActive(false);
                    cars.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                }
                else
                {
                    cars.transform.GetChild(i).gameObject.SetActive(false);
                    cars.transform.GetChild(i + 1).gameObject.SetActive(true);
                    break;
                }

            }
        }
    }

   
}
