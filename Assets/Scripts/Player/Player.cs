using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{

    [SerializeField] private GameObject gameCam;

    [Header("Physics")]
    [SerializeField] private Rigidbody2D m_RigidBody;


    //Movement related variables and methods
    [Header("Movement")]
    [SerializeField] float playerSpeed;
    float moveHorizontal;
    float moveVertical;
    bool isPlayerMoving;
    Vector2 mouseTargetPos;

    //Player States
    [Header("PlayerStates")]
    [SerializeField] string currentState;
    [SerializeField] string previousState;
    [SerializeField]
    enum PlayerStates
    {
        Idle, Walk, Run, Death, Attack
    };
    PlayerStates m_playerStates = PlayerStates.Idle;

    //Player Animations
    [Header("Animation")]
    [SerializeField] Animation state1;
    [SerializeField] Animator m_Animator;
    [SerializeField]
    enum PlayerAnimationStates
    {
        Idle, Walk, Run, Death, Attack, Hit
    }
    PlayerAnimationStates m_playerAnimationStates = PlayerAnimationStates.Idle;


    //Customizable inputs
    [SerializeField] enum PlayerInputs { };

    private void Awake()
    {
        if (!IsOwner) return;

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            gameCam.SetActive(false);
            return;
        }
        GetPlayerInputs();
        PlayerStateMachine();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;
        if (isPlayerMoving) MovePlayer();
    }

    void GetPlayerInputs()
    {
        //moveHorizontal = Input.GetAxis("Horizontal");
        //moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                mouseTargetPos = new Vector2(hit.point.x, hit.point.y);
                m_playerStates = PlayerStates.Walk;
            }
        }
    }

    #region Movement
    void MovePlayer()
    {
        Vector2 current2dPos = new Vector2(transform.position.x, transform.position.y);
        if (current2dPos.sqrMagnitude != mouseTargetPos.sqrMagnitude)
            m_RigidBody.MovePosition(Vector2.Lerp(current2dPos, mouseTargetPos, playerSpeed / 1000f));
        else
        {
            isPlayerMoving = false;
            m_Animator.SetBool("Walk", false);
        }
        //MyRigidBody.velocity = new Vector2(moveHorizontal * playerSpeed, moveVertical * playerSpeed);
    }
    #endregion

    #region PlayerStates
    void PlayerStateMachine()
    {
        switch (m_playerStates)
        {
            case PlayerStates.Idle:
                break;
            case PlayerStates.Run:
                break;
            case PlayerStates.Walk:
                m_Animator.SetBool("Walk", true);
                isPlayerMoving = true;
                break;
            case PlayerStates.Death:
                break;
            case PlayerStates.Attack:
                break;
        }
    }

    #endregion
}
