using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMapSrc : MonoBehaviour
{
    [SerializeField] private GameObject _loadTextPref;
    [SerializeField] private Transform _setParentText;
    private List<string> _saveMapSrc;
    private List<GameObject> _tempGameObjText;
    private ShutReycaster _shutReycaster;

    private void Start()
    {
        _shutReycaster = GetComponent<ShutReycaster>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickOnObjLoad(_shutReycaster.PointRayCast());
        }
    }
    public void OpenWindowLoad()
    {
        _saveMapSrc = new SaveMapSrc().GetAllMapInFolder();
        _tempGameObjText = new List<GameObject>();
        GameObject tempLoadText;

        foreach (var item in _saveMapSrc)
        {
            tempLoadText = Instantiate(_loadTextPref, _setParentText);
            tempLoadText.transform.gameObject.GetComponent<Text>().text = "„K„p„‚„„„p ‡‚ " + item;
            _tempGameObjText.Add(tempLoadText);
        }
    }
    private void ClickOnObjLoad(GameObject getClickObj)
    {
        if (getClickObj.layer == 7)
        {
            getClickObj.transform.gameObject.GetComponent<Text>().text = "„S„\ „N„@„G„@„L „N„@ „N„E„C„O -_- „O„O„O„O„O„O„O„O„O „N„E„E„E„E„E„E„E„E„E„E„E„E„S„S„S„S„S„S„S„S„S„S";
        }
    }
    private void LoidInFolder()
    {

    }
    public void CloseWindowLoadDestroyText()
    {
        foreach (GameObject item in _tempGameObjText)
        {
            Destroy(item);
        }
    }
}
