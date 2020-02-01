using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Player Character;
    [SerializeField] private List<GameObject> Levels;
    [SerializeField] private List<GameObject> Instructions;
    [SerializeField] private GameObject Hud;
    [SerializeField] private GameObject Menu;
    [SerializeField] private Transform InstructionPosition;

    private GameObject CurrentLevel;
    private GameObject CurrentInstruction;
    private bool FinishedInstruction;

    //Time limit
    private float Timer = 30;

    // Update is called once per frame
    private void Start()
    {
        ShowMenu(true);
    }

    void Update()
    {
        if (Menu.activeInHierarchy != true)
        {
            Timer -= Time.deltaTime;
            Hud.GetComponent<HUD>().UpdateTimer(Timer);
            if (Timer > 0 && FinishedInstruction == true)
            {
                //New instruction
            }
        }
    }

    public void ShowMenu(bool show)
    {
        Hud.SetActive(!show);
        Menu.SetActive(show);
        if(show)
        {

        }
        else
        {

        }
    }

    public void StartGame()
    {
        ShowMenu(false);
        CurrentLevel = Instantiate(Levels[0],  transform);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Change(int choice)
    {
        if (CurrentInstruction != null)
            Destroy(CurrentInstruction);
        CurrentInstruction = Instantiate(Instructions[choice],InstructionPosition);
    }
}
