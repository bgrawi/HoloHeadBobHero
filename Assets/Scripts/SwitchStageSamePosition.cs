using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class SwitchStageSamePosition : MonoBehaviour {

    public GameObject HideStage;

    public GameObject ShowStage;

    void OnSelect()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(new Ray(headPosition, gazeDirection), out hitInfo, 100f, SpatialMappingManager.Instance.WallMask))
        {
            Destroy(hitInfo.collider.gameObject);
        }

        GameObject.FindGameObjectWithTag("SpatialMapper").SetActive(false);


        ShowStage.transform.position = this.transform.position;
        ShowStage.transform.rotation = this.transform.rotation;

        HideStage.SetActive(false);
        ShowStage.SetActive(true);
    }
}
