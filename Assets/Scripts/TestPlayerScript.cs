using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
    //UI-Debug related
    private TextMeshProUGUI UITextPlayerPos;
    private TextMeshProUGUI UITextMousePos;


    //Moving related
    [SerializeField]
    private TestMarkerPoint _markerPref;
    private Vector3 newPostion;

    private Camera _camera;

    public float speed = 0.03f;


    //Animation related
    private Animator _animator;

    public int characterSide = 0; //Im to lazy to use enum... 0 back, 1 front
    public bool isIdle = true;

    private float characterDir = 0.0f;
    public float CharacterDir
    {
        get => characterDir;
        set
        {
            characterDir = value;
            if(value > 90 || value < -90)
            {
                characterSide = 0;
            }
            else
            {
                characterSide = 1;
            }
        }
    }

    

    void Start()
    {
        UITextPlayerPos = GameObject.FindWithTag("UITestPlayerPosition").GetComponent<TextMeshProUGUI>();
        UITextMousePos = GameObject.FindWithTag("UIMousePosition").GetComponent<TextMeshProUGUI>();

        newPostion = transform.position;
        _camera = Camera.main;
        _camera.GetComponent<TestCameraFollow>().ObjectToFollow = gameObject;

        _animator = GetComponent<Animator>();
    }

    void Update()
    {

        isIdle = MoveCharacter();
        CharacterDir = GetCharacterAngle();
        AnimateCharacter();


        RefreshDebugValues();
    }
    private float GetCharacterAngle()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Vector3 dirVec = Vector3.Normalize(mousePos - transform.position);

        return Mathf.Rad2Deg * Mathf.Atan2(dirVec.y, dirVec.x);
    }

    private void AnimateCharacter()
    {
        if(_animator != null)
        {
            _animator.SetInteger("CharacterSide", characterSide);
            _animator.SetFloat("CharacterDir", characterDir);
            _animator.SetBool("isIdle", isIdle);
        }
    }

    private bool MoveCharacter()
    {
        if (Input.GetMouseButtonDown(1))
        {
            newPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPostion.z = transform.position.z;


            Instantiate<TestMarkerPoint>(_markerPref, newPostion, transform.rotation);
        }
        if (Input.GetMouseButton(1))
        {
            newPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPostion.z = transform.position.z;
        }

        
        Vector3 prevPosition = transform.position;
        transform.position = Vector3.Lerp(transform.position, newPostion, speed);
        if(transform.position != prevPosition)
        {
            return false;
        }
        return true;
    }



    private void RefreshDebugValues()
    {
        if (UITextPlayerPos != null)
        {
            UITextPlayerPos.text = transform.position.ToString();
        }
        //if (UITextMousePos != null)
        //{
        //    UITextMousePos.text = "(" + Input.GetAxisRaw("Horizontal") + ", " + Input.GetAxisRaw("Vertical") + ")";
        //}
    }
}