using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class StartMainStage : MonoBehaviour
{

    public GameObject MenuStage;

    public GameObject MainStage;

    void OnSelect()
    {
        MainStage.transform.position = this.transform.position;
        MainStage.transform.rotation = this.transform.rotation;

        var vec = MainStage.transform.eulerAngles;
        vec.x = 0;
        vec.y = Mathf.Round((vec.y + 180) / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;
        MainStage.transform.eulerAngles = vec;

        MenuStage.SetActive(false);
        MainStage.SetActive(true);
    }
}
