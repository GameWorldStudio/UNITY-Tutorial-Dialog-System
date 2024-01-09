using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    int currentObjectiveIndex = 0;
    public List<GameObject> allObjectiveSpot; // Dois contenir la liste de tout les spots dans l'ordre

    public delegate void OnFinishObjective();
    public static OnFinishObjective OnObjectiveFinish;

    private void Awake()
    {
        OnObjectiveFinish += NextObjective;
    }

    public void NextObjective()
    {
        allObjectiveSpot[currentObjectiveIndex].SetActive(false);

        if(currentObjectiveIndex != allObjectiveSpot.Count - 1)
        {
            currentObjectiveIndex++;
            allObjectiveSpot[currentObjectiveIndex].SetActive(true);
        }
    }
}
