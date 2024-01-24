    
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    [SerializeField] private Text currentLevel, currentPoints, health, damage, speed;
    [SerializeField] GameObject lvlUp;

    private void Start()
    {
        currentLevel.text = "Current Level : " + FindObjectOfType<Level>().level;
        currentPoints.text = "Current points : " + FindObjectOfType<Level>().points;
        isPaused = false;

    }
    void Update()
    {
        currentLevel.text = "Current Level : " + FindObjectOfType<Level>().level;
        currentPoints.text = "Current points : " + FindObjectOfType<Level>().points;
        health.text = "Max health: " + FindObjectOfType<takeHit>().maxHealth;
        damage.text = "Damage: " + FindObjectOfType<Attack>().damage;
        speed.text = "Speed: " + FindObjectOfType<Movement>().speed;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused) resume();
            else pause();

        }
    }

    public void resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void quit()
    { 
        Application.Quit(); 
    }

    public void addHealth()
    {
        if (FindObjectOfType<Level>().points > 0)
        {
            lvlUp.SetActive(false);
            FindObjectOfType<Level>().points--;
            FindObjectOfType<takeHit>().maxHealth += 20;
            FindObjectOfType<takeHit>().health = FindObjectOfType<takeHit>().maxHealth;
        }
    }
    public void addDamage()
    {
        if (FindObjectOfType<Level>().points > 0)
        {
            lvlUp.SetActive(false);
            FindObjectOfType<Level>().points--;
            FindObjectOfType<Attack>().damage += 20;
            
        }
    }
    public void addpeed()
    {
        if (FindObjectOfType<Level>().points > 0)
        {
            lvlUp.SetActive(false);
            FindObjectOfType<Level>().points--;
            FindObjectOfType<Movement>().speed += 20;
           
        }
    }



}
