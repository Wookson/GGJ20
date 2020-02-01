using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private TextMeshProUGUI NextInstruction;
    [SerializeField] private List<GameObject> Strikes;

    void Update()
    {
        
    }

    public void UpdateStrikes(int Amount)
    {
        for(int i = 0; i < Amount; i++)
        {
            Destroy(Strikes[Strikes.Count - Amount]);
        }
    }

    public void UpdateTimer(float Time)
    {
        Timer.text = "Time Left - " + Time;
    }

    public void UpdateInstruction(string instruction)
    {
        NextInstruction.text = "Instruction - " + instruction;
    }
}
