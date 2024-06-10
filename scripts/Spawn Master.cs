using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine;

public class SpawnMaster : MonoBehaviour
{
    public GameObject game_over;
    public GameObject gameview;
    public GameObject wave_finished;
    public GameObject lastspawned;
    public TextMeshProUGUI base_health_text;
    public TextMeshProUGUI wave;
    public UnityEngine.UI.Slider base_health_slider;
    public int setstartbudget = 500;
    int roundbudget;
    public int round_budget_increase_percent = 20;
    public int budget=0;
    int i=0;
    int wave_nr;
    public int base_health=500;
    public int current_base_health;
    // Start is called before the first frame update
    void Start()
    {
        wave_nr = 0;
        wave.text = "wave " + wave_nr;
        base_health_slider.maxValue = base_health;
        current_base_health = base_health;
        roundbudget = setstartbudget;
        game_over.SetActive(false);
        gameview.SetActive(true);
        wave_finished.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_base_health == 0 && game_over.activeSelf == false)
        {
            game_over.SetActive(true);
            gameview.SetActive(false);
            wave_finished.SetActive(false);

        }
        else if (lastspawned == null && budget == 0 && game_over.activeSelf == false)
        {
            wave_finished.SetActive(true);
        }
        base_health_text.text = current_base_health + " / " + base_health;
        base_health_slider.value = current_base_health;
    }

    public void New_Round()
    {
        if (i == 0)
        {
            roundbudget = setstartbudget;
            current_base_health = base_health;
            base_health_slider.maxValue = base_health;
            budget = roundbudget;
            i = 1;
            wave_nr = 1;
            wave.text = "wave " + wave_nr;
        }
        else
        { 
            roundbudget = roundbudget + roundbudget / 100 * round_budget_increase_percent;
            budget = roundbudget;
            wave_nr++;
            wave.text = "wave " + wave_nr;
        }
        wave_finished.SetActive(false);
    }
    public void Reset_Game()
    {
        wave_nr = 0;
        wave.text = "wave " + 0;
        i = 0;
        current_base_health = base_health;
        game_over.SetActive(false);
        gameview.SetActive(true);
        wave_finished.SetActive(true);

    }
}
