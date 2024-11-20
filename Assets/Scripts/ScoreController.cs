using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] public int coinsByNow;
    [SerializeField] private TextMeshProUGUI textMesh;

    // Unique instance
    public static ScoreController Instance;

    public delegate void MoneyEarnedDelegate(float currentMoney);
    public MoneyEarnedDelegate moneyEarnedEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        moneyEarnedEvent += UpdateScoreText;
    }

    private void OnDisable()
    {
        moneyEarnedEvent -= UpdateScoreText;
    }

    public void AddCoins(int someCoins)
    {
        coinsByNow += someCoins;
        moneyEarnedEvent?.Invoke(coinsByNow);
    }

    private void UpdateScoreText(float currentMoney)
    {
        if (textMesh != null)
        {
            textMesh.text = $"Points: {currentMoney}";
        }
    }
}
