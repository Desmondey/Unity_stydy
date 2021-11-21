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

    public void CloseWindowLoadDestroyText()
    {
        foreach (GameObject item in _tempGameObjText)
        {
            Destroy(item);
        }
    }
}
