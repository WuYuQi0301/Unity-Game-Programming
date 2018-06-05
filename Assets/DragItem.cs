using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform m_tranform;
    RectTransform m_rectTransform;
    Vector3 previousPosition;
    CanvasGroup canvasGroup;
    GameObject previousGamebject;
    Texture previousImage;

    // Use this for initialization
    void Start () {
        m_tranform = this.gameObject.transform;
        m_rectTransform = this.transform as RectTransform;
        canvasGroup = GetComponent<CanvasGroup>();
        previousPosition = m_tranform.position;
        Debug.Log("start");
        Debug.Log(gameObject.name);
	}

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        try
        {
            /*让event trigger忽略自身，
             *这样才可以让event trigger检测到它下面一层的对象,如包裹或物品格子等
             */
            canvasGroup.blocksRaycasts = false;
            previousGamebject = eventData.pointerEnter;
            Debug.Log(previousGamebject);
            previousPosition = m_tranform.position;
            /*
             * 保证当前操作的对象能够优先渲染
             * 即不会被其它对象遮挡住
             */
            gameObject.transform.SetAsLastSibling();
        }
        catch (Exception e) {
            throw new System.NotImplementedException();
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        try
        {
            Vector2 mousePos;
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(m_rectTransform, eventData.position, eventData.pressEventCamera, out mousePos))
            {
                m_rectTransform.position = mousePos;
            }
            GameObject currentGameObject = eventData.pointerEnter;

            bool isin = IsInContainer(currentGameObject);
            if(isin == true)
            {
                Image img = currentGameObject.GetComponent<Image>();
                previousGamebject.GetComponent<Image>().image = previousImage;
                if (previousGamebject != currentGameObject)
                {
                    previousGamebject.GetComponent<Image>().image = previousImage;
                    previousGamebject = currentGameObject;//记录当前物品格子以供下一帧调用
                }
            }
        }
        catch (Exception e)
        {
            throw new System.NotImplementedException();
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        try
        {
            GameObject currentContainer = eventData.pointerEnter;
            if(currentContainer == null)
            {
                m_tranform.position = previousPosition;
            }
            else if(currentContainer.name == "Container")
            {
                m_tranform.position = currentContainer.transform.position;
                previousPosition = m_tranform.position;
                currentContainer.GetComponent<Image>().image = previousImage;//当前格子恢复正常颜色
            }
            else if(currentContainer.name == eventData.pointerDrag.name && currentContainer!= eventData.pointerDrag)
            {
                Vector3 temp = currentContainer.transform.position;
                currentContainer.transform.position = previousPosition;
                m_tranform.position = temp;
                previousPosition = m_tranform.position;
            }
            else
            {
                m_tranform.position = previousPosition;
            }
            canvasGroup.blocksRaycasts = true;
        }
        catch (Exception e)
        {
            throw new System.NotImplementedException();
        }
    }

    bool IsInContainer(GameObject gm)
    {
        if (gm == null)
        {
            return false;
        }
        return gm.name == "Container";
    }
}
