using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIElementDraggerPuzzle : MonoBehaviour {

    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;

    private Vector2 originalPosition;
    private Transform objectToDrag; 
    private Image objectToDragImage;

    [SerializeField]
    private GameObject gameManager;

    List<RaycastResult> hitObjects = new List<RaycastResult>();
    
    #region Monobehaviour API

    void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                if (!objectToDrag.GetComponent<Tile_>().GetIsTarget()){
                    dragging = true;

                    objectToDrag.SetAsLastSibling();

                    originalPosition = objectToDrag.position;
                    objectToDragImage = objectToDrag.GetComponent<Image>();
                    objectToDragImage.raycastTarget = false;
                }else{
                    objectToDrag = null;
                }
            }
        }

        if (dragging)
        {
            Camera cam = GetComponent<Camera>();
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
            objectToDrag.position = point;
            // objectToDrag.position = Input.mousePosition;
        }
    
        if (Input.GetMouseButtonUp(0))
        {
            


            if (objectToDrag != null)
            {
                var objectToReplace = GetDraggableTransformUnderMouse();
                if (objectToReplace != null)
                {
                    if(objectToReplace.GetComponent<Tile_>().GetIsTarget() && objectToDrag.GetComponent<Tile_>().GetNumber() == objectToReplace.GetComponent<Tile_>().GetNumber()){
                        // objectToDrag.position = objectToReplace.position;
                        // objectToReplace.position = originalPosition;
                        // gameManager.GetComponent<GM_TebakBentuk>().CheckAnswer();
                        gameManager.GetComponent<GM_PuzzleHuruf>().IncreaseRightPoint();
                        objectToDrag.GetComponent<Image>().enabled= false;
                    }
                }

                objectToDrag.position = originalPosition;
                

                objectToDragImage.raycastTarget = true;
                objectToDrag = null;

                
            }

            dragging = false;
           
        }
	}

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0) return null;

        return hitObjects.First().gameObject;        
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        var clickedObject = GetObjectUnderMouse();

        // get top level object hit
        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }

    #endregion
}
