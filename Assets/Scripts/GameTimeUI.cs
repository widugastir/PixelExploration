using UnityEngine.UI;
using UnityEngine;

public class GameTimeUI : MonoBehaviour
{
    private Text _timer;

    private void Awake() => _timer = GetComponent<Text>();
    private void OnEnable() => GameTime.OnTick += OnGameTimeTick;
    private void OnDisable() => GameTime.OnTick -= OnGameTimeTick;
    private void OnGameTimeTick(int time) => _timer.text = $"- {time} -";
}
