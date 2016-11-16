using UnityEngine;
using System.Collections;

public class SwitchStageSamePosition : MonoBehaviour {

    public GameObject HideStage;

    public GameObject ShowStage;

    void OnSelect()
    {
        ShowStage.transform.position = this.transform.position;
        ShowStage.transform.rotation = this.transform.rotation;

        HideStage.SetActive(false);
        ShowStage.SetActive(true);
    }
}
