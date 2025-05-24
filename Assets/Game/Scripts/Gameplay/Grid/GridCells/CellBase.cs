using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBase : MonoBehaviour
{
    protected GridController spawner;
    private TapController tapController;
    private GameObject selectedCue;
    private bool isInEditor;
    private Vector2Int cellPos;

    private void Awake()
    {
        tapController = GetComponent<TapController>();
        if (tapController == null)
        {
            tapController = gameObject.AddComponent<TapController>();
        }
        Transform selectedCueTrans = transform.Find("Cylinder");
        selectedCue = selectedCueTrans.gameObject;
        tapController.OnTapped.AddListener(HandleTap);
    }
    private void OnDestroy()
    {
        if (tapController != null)
        {
            tapController.OnTapped.RemoveListener(HandleTap);
        }
    }

    public void InitializeCell(Vector2Int pos, GridController controller)
    {
        spawner = controller;
        cellPos = pos;
        if (controller is EditorGridController)
            isInEditor = true;
    }

    private void HandleTap()
    {
        if (!isInEditor)
            return;
        EditorGridController editorGrid = spawner as EditorGridController;
        if (!editorGrid.IsInEditMode)
            return;
        editorGrid.OnTileClicked(cellPos);
    }

    public void CellSelected()
    {
        if (!isInEditor) return;
        selectedCue.SetActive(true);
    }

    public void CellDeselected()
    {
        if (!isInEditor) return;
        selectedCue.SetActive(false);
    }

}


//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/
