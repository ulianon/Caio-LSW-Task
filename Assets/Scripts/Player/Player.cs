using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{

    [Header("Physics")]
    private Rigidbody2D MyRigidBody;


    //Movement related variables and methods
    [Header("Movement")]
    [SerializeField] float playerSpeed;
    float moveHorizontal;
    float moveVertical;
    Vector2 mouseTargetPos;

    //Player States
    [Header("PlayerStates")]
    [SerializeField] string currentState;
    [SerializeField] string previousState;
    [SerializeField] enum PlayerStates { };

    //Customizable inputs
    [SerializeField] enum PlayerInputs { };

    private void Awake()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void GetPlayerInputs()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                mouseTargetPos = new Vector2(hit.point.x, hit.point.y);
                
            }
        }
    }
    #region Movement
    void MovePlayer()
    {
        Vector2 current2dPos = new Vector2(transform.position.x, transform.position.y);
        MyRigidBody.MovePosition(Vector2.Lerp(current2dPos, mouseTargetPos, playerSpeed/1000f));

        Vector3 TestCommitomgchanged;
        //MyRigidBody.velocity = new Vector2(moveHorizontal * playerSpeed, moveVertical * playerSpeed);
    }

    #endregion
    void MovePlayer23()
    {
        Vector2 current2dPos = new Vector2(transform.position.x, transform.position.y);
        MyRigidBody.MovePosition(Vector2.Lerp(current2dPos, mouseTargetPos, playerSpeed / 1000f));

        Vector3 TestCommitomgchanged;
        //MyRigidBody.velocity = new Vector2(moveHorizontal * playerSpeed, moveVertical * playerSpeed);
    }
    #region PlayerStates
    #endregion
}
