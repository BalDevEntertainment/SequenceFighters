using Domain;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionButton : MonoBehaviour
{
    public CurrentInput CurrentInput;
    public PlayerActionName ActionName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(CallAction);
    }

    private void CallAction()
    {
        CurrentInput.AddAction(new PlayerActionViewModel(ActionName, GetComponent<Button>().image.sprite));
    }
}