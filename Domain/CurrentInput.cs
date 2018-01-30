using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Domain
{
    public class CurrentInput : MonoBehaviour
    {
        public GameObject Hero;
        public Image PlayerInput;

        private readonly List<PlayerActionViewModel> _currentInputs =
            new List<PlayerActionViewModel>();

        private bool _shouldUpdate;

        private void Update()
        {
            if (_shouldUpdate)
            {
                var newPlayerInput = Instantiate(PlayerInput, transform);
                newPlayerInput.sprite = _currentInputs.Last().Image;
                _shouldUpdate = false;
            }
        }

        public void AddAction(PlayerActionViewModel action)
        {
            _currentInputs.Add(action);
            _shouldUpdate = true;
        }

        public void Execute()
        {
            if (IsSequenceValid())
            {
                Attack();
            }
            else
            {
                Miss();
            }
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }
            _currentInputs.Clear();

        }

        private bool IsSequenceValid()
        {
            var validSequence = new List<PlayerActionName>
            {
                PlayerActionName.Attack,
                PlayerActionName.HeavyAction,
                PlayerActionName.HeavyAction,
                PlayerActionName.HeavyAction
            };
            for (int i = 0; i < _currentInputs.Count; i++)
            {
                if (validSequence.Count > i)
                {
                    if (!_currentInputs[i].Name.ToString().Equals(validSequence[i].ToString()))
                    {
                        return false;
                    }
                }
            }
            return _currentInputs.Count == validSequence.Count;
        }

        private void Miss()
        {
            Hero.GetComponent<Animator>().SetTrigger("hit_1");
        }

        private void Attack()
        {
            Hero.GetComponent<Animator>().SetTrigger("skill_1");
        }
    }
}

[Serializable]
public class PlayerActionViewModel
{
    public Sprite Image;
    public PlayerActionName Name;

    public PlayerActionViewModel(PlayerActionName name, Sprite image)
    {
        Name = name;
        Image = image;
    }
}

public enum PlayerActionName
{
    Attack,
    Defend,
    Item,
    LightAction,
    MediumAction,
    HeavyAction
}