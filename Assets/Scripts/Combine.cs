using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    [SerializeField] private Game game;
    private List<GameObject> Contains;

    private void MakeItem()
    {
        for(int i = 0; i < Contains.Count; i++)
        {
            if(Contains.Contains(game.Parts[0]) && Contains.Contains(game.Parts[1]) && Contains.Contains(game.Parts[2]))
            {
                for(int j = 0; j < Contains.Count; j++)
                {
                    if (Contains[j] == game.Parts[0] || Contains[j] == game.Parts[1] || Contains[j] == game.Parts[2])
                    {
                        Destroy(Contains[j]);
                        Contains.Remove(Contains[j]);
                    }
                }
                game.CurrentParts.Add(game.Items[0]);
            }
            else if (Contains.Contains(game.Parts[2]) && Contains.Contains(game.Parts[3]) && Contains.Contains(game.Parts[4]))
            {
                for (int j = 0; j < Contains.Count; j++)
                {
                    if (Contains[j] == game.Parts[2] || Contains[j] == game.Parts[3] || Contains[j] == game.Parts[4])
                    {
                        Destroy(Contains[j]);
                        Contains.Remove(Contains[j]);
                    }
                }
                game.CurrentParts.Add(game.Items[1]);
            }
            else if (Contains.Contains(game.Parts[4]) && Contains.Contains(game.Parts[5]) && Contains.Contains(game.Parts[6]))
            {
                for (int j = 0; j < Contains.Count; j++)
                {
                    if (Contains[j] == game.Parts[4] || Contains[j] == game.Parts[5] || Contains[j] == game.Parts[6])
                    {
                        Destroy(Contains[j]);
                        Contains.Remove(Contains[j]);
                    }
                }
                game.CurrentParts.Add(game.Items[2]);
            }
            else if (Contains.Contains(game.Parts[5]) && Contains.Contains(game.Parts[6]) && Contains.Contains(game.Parts[7]))
            {
                for (int j = 0; j < Contains.Count; j++)
                {
                    if (Contains[j] == game.Parts[5] || Contains[j] == game.Parts[6] || Contains[j] == game.Parts[7])
                    {
                        Destroy(Contains[j]);
                        Contains.Remove(Contains[j]);
                    }
                }
                game.CurrentParts.Add(game.Items[3]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(game.Parts.Contains(other.gameObject) && !Contains.Contains(other.gameObject))
        {
            Contains.Add(other.gameObject);
            MakeItem();
        }
    }
}
