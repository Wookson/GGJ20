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
    [SerializeField] private List<GameObject> Items;
    [SerializeField] private List<GameObject> Parts;
    [SerializeField] private List<GameObject> Tools;
    [SerializeField] private List<GameObject> Conveyors;
    [SerializeField] private GameObject Hud;
    [SerializeField] private GameObject Menu;
    [SerializeField] private Transform InstructionPosition;

    public List<GameObject> CurrentParts;
    public List<GameObject> Difficulty;
    private GameObject CurrentLevel;
    private GameObject CurrentInfo;
    private GameObject CurrentInstruction;
    private bool FinishedInstruction;

    //Time limit
    private float Timer = 30;

    // Update is called once per frame
    private void Start()
    {
        ShowMenu(true);
        FinishedInstruction = true;
        for (int i = 0; i < 3; i++)
        {
            CurrentInstruction = Items[Random.Range(0, Items.Count)];
            Difficulty.Add(CurrentInstruction);
        }
    }

    void Update()
    {
        if (Menu.activeInHierarchy != true)
        {
            if (CurrentParts.Count == 0)
            {
                //Make it wait to fire from conveyor belt
                for (int i = 0; i < Difficulty.Count; i++)
                {
                    PrepareParts(Difficulty[i]);
                }
                CurrentParts.Add(Instantiate(Tools[0], this.transform));
                CurrentParts.Add(Instantiate(Tools[1], this.transform));
                for(int i = 0; i < CurrentParts.Count;i++)
                {
                    CurrentParts[i].transform.position = Conveyors[1].transform.position;
                    CurrentParts[i].GetComponent<Rigidbody2D>().velocity += Vector2.left;
                    StartCoroutine(WaitSec(1,CurrentParts[i]));
                }
            }
            Timer -= Time.deltaTime;
            Hud.GetComponent<HUD>().UpdateTimer(Timer);
            if (Timer < 0 || FinishedInstruction == true)
            {
                if (Difficulty.Count != 0)
                {

                    if (Difficulty.Count == 3)
                        CurrentInstruction = Difficulty[Difficulty.Count-1];
                    else
                    {
                        Difficulty.RemoveAt(Difficulty.Count - 1);
                        CurrentInstruction = Difficulty[Difficulty.Count-1];
                    }
                    FinishedInstruction = false;
                    //hud instruction display needts to be done
                }
            }
            
        }
    }

    private void PrepareParts(GameObject item)
    {
        if (item == Items[0])
        {
            for(int i = 0; i < 3; i++)
            {
                CurrentParts.Add(Instantiate(Parts[0 + i], this.transform));
            }
        }
        else if (item == Items[1])
        {
            for (int i = 0; i < 3; i++)
            {
                CurrentParts.Add(Instantiate(Parts[2 + i], this.transform));
            }
        }
        else if (item == Items[2])
        {
            for (int i = 0; i < 3; i++)
            {
                CurrentParts.Add(Instantiate(Parts[4 + i], this.transform));
            }
        }
        else if (item == Items[3])
        {
            for (int i = 0; i < 3; i++)
            {
                CurrentParts.Add(Instantiate(Parts[5 + i], this.transform));
            }
        }
    }

    private IEnumerator WaitSec(float wait, GameObject part)
    {
        yield return new WaitForSeconds(wait);
        part.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
            for(int i=0; i<Conveyors.Count; i++)
            {
                Instantiate(Conveyors[i],transform);
            }
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
        if (CurrentInfo != null)
            Destroy(CurrentInfo);
        CurrentInfo = Instantiate(Instructions[choice],InstructionPosition);
    }
}
