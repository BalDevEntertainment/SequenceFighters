using Domain;
using UnityEngine;
using UnityEngine.UI;

public class InputTimerComponent : MonoBehaviour
{
    public float InputTime = 3f;
    public CurrentInput CurrentInput;
    private float _remainingTime;
    private Slider _progressBar;

    private void Start()
    {
        _remainingTime = InputTime;
        _progressBar = GetComponent<Slider>();
    }

    void Update()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            _progressBar.value = _remainingTime / InputTime;
        }
        else
        {
            _remainingTime = InputTime;
            CurrentInput.Execute();
        }
    }
}