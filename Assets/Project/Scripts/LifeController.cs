using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public enum On_DefeatBheaviour { DISABLE, DESTROY };
    [SerializeField] private int _currentHp = 100;
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private bool _fullHpOnStart = true;
    [SerializeField] On_DefeatBheaviour _defeatBheaviour = On_DefeatBheaviour.DESTROY;
    public int GetHp() => _currentHp;
    public int MaxHp() => _maxHp;
    void Start()
    {
        if (_fullHpOnStart) SetHp(_maxHp);
    }

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);
        _currentHp = hp;
        if (_currentHp == 0)
        {
            switch (_defeatBheaviour)
            {
                default:
                    Debug.Log($" {_defeatBheaviour} not existing");
                    break;
                case On_DefeatBheaviour.DISABLE:
                    gameObject.SetActive(false);
                    break;
                case On_DefeatBheaviour.DESTROY:
                    Destroy(gameObject);
                    break;
            }
        }
    }
    public void SetMaxHp(int maxHp)
    {
        _maxHp = Mathf.Max(1, maxHp);
        SetHp(_currentHp);
    }
    public void AddHp(int amount) => SetHp(_currentHp + amount);
}
