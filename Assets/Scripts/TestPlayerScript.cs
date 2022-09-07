using UnityEngine;

//always remove not used libraries

public class TestPlayerScript : MonoBehaviour
{
    private Vector3 newPosition;
    private float newT;
    private Camera _camera;

    private bool isFollowOn;

    private Vector2 targetPos;

    public Vector2 TargetPos
    {
        get => targetPos;
        set => targetPos = value;
    }

    public Vector2 CurrPos
    {
        get => new Vector2(transform.position.x,transform.position.y); 
    }


    public float speed = 4f;

    //mivel semmi sem használja egyelőre a dolgokat, nem muszáj, de getter setter-re szokjunk rá, ahol van értelme

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        _camera = Camera.main;
        _camera.GetComponent<TestCameraFollow>().ObjectToFollow = gameObject;
        Debug.Log(_camera.gameObject.name);

        MouseScript.OnRightClickDown += RefreshTargetPos;

    }

    void RefreshTargetPos(Vector2 mousePos)
    {
        Debug.Log("Másik oldal:" +mousePos);
        targetPos = mousePos;
    }

    void MoveToTarget()
    {
        //Distance function returns the distance between two vector2's in float
        if (Vector2.Distance(targetPos, CurrPos)>.5f)
        {
            transform.position = Vector2.MoveTowards(CurrPos, targetPos, speed);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _camera.GetComponent<TestCameraFollow>().ObjectToFollow = isFollowOn ? gameObject: null;
            isFollowOn = !isFollowOn;
            Debug.Log("toggle");
        }

        // Ctrl-K-D komment, Ctrl K-U uncomment kijelölt szöveg
        //if (Input.GetMouseButtonDown(1))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        //    {
        //        newPostion = hit.point;
        //        newT = Time.time;
        //    }

        //    Debug.Log(hit.point);
        //}
        //transform.position = Vector3.Lerp(transform.position, targetPos, speed);
        MoveToTarget();

    }

    void OnEnable()
    {
        MouseScript.OnRightClickDown += RefreshTargetPos;
    }

    void OnDisable()
    {
        MouseScript.OnRightClickDown -= RefreshTargetPos;
    }
}