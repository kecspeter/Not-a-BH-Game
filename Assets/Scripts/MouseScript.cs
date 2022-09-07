using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class MouseScript : MonoBehaviour
{
    private Vector2 mousePos;
    UnityEvent keydownEvent;

    public UnityEvent KeyDownEvent 
    {
        get => keydownEvent; 
        set => keydownEvent = value;
    }

    public Vector2 MousePos
    {
        get => mousePos;
        set => mousePos = value;
    }

    public delegate void RightClickDown(Vector2 mPos);
    public static event RightClickDown OnRightClickDown;

    // event delegation : https://www.monkeykidgc.com/2020/07/how-to-use-events-in-unity-with-c.html

    // Start is called before the first frame update
    void Start()
    {
        KeyDownEvent = new UnityEvent();
        KeyDownEvent.AddListener(OnKeyDown);
    }

    // Update is called once per frame
    void Update()
    {
        // #1 ezt kecire nem így kéne, majd megnézem hogy
        // #2 jövőben nem beleégetni hanem szépen kiszedni változóba
        if (Input.GetKey(KeyCode.Mouse1))
        {
            KeyDownEvent.Invoke();
            //ennek nagy része felesleges, de később jó lesz #copium
        }
    }

    void OnKeyDown()
    {
        //Debug.Log("MousePos: "+MousePos.x+","+MousePos.y);
        // ha nincs senki feliratkozva, exception-t dob.
        if (OnRightClickDown != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                MousePos = hit.point;
            }
            OnRightClickDown(MousePos);
        }
    }
}
