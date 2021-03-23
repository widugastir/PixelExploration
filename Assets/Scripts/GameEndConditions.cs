using UnityEngine;

public class GameEndConditions : MonoBehaviour
{
    [SerializeField] private int _timeToLose = 3;
    [SerializeField] private int _scrapToWin = 1;

    private void OnEnable() {
        Resources.OnResourceChange += OnResourceChange;
        GameTime.OnTick += OnGameTimeTick;
    }

    private void OnDisable() {
        Resources.OnResourceChange -= OnResourceChange;
        GameTime.OnTick -= OnGameTimeTick;
    }

    private void OnResourceChange(ResourceType type, int amount)
    {
        if(type == ResourceType.Scrap && amount >= _scrapToWin)
        {
            Victory();
        }
    }

    private void OnGameTimeTick(int time) 
    { 
        if(time >= _timeToLose)
        {
            Defeat();
        }
    }

    private void Victory()
    {
        // Victory methods..
        
        print("Victory!");
        Time.timeScale = 0f;
    }

    private void Defeat()
    {
        // Defeat methods..

        print("Defeat!");
        Time.timeScale = 0f;
    }
}
