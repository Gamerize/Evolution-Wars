using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    float MovSpeed = 1f;
    bool Moved;
    bool NextTurn;
    int Mov;
    public int order;
    int TurnValue;

    [SerializeField] TurnManager Turn;

    // Start is called before the first frame update
    void Start()
    {
        Mov = 5;
        Moved = false;
        NextTurn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!NextTurn)
            {
                TurnValue = Turn.CurrentTurn();
                NextTurn = true;
                if (TurnValue == order)
                {
                    MovementReset();
                    Movement();
                }
            }
        }
        NextTurn = false;
    }

    // Update is called once per frame
    public void Movement()
    {
        Vector3 MovementUp = new Vector3(transform.position.x - MovSpeed, transform.position.y, transform.position.z);
        Vector3 MovementDown = new Vector3(transform.position.x - MovSpeed, transform.position.y, transform.position.z);
        Vector3 MovementLeft = new Vector3(transform.position.x, transform.position.y, transform.position.z + MovSpeed);
        Vector3 MovementRight = new Vector3(transform.position.x, transform.position.y, transform.position.z - MovSpeed);

        while (Moved == false && Mov != 0)
        {
            if(Input.GetKeyDown(KeyCode.A) && WalkableSpace(MovementLeft))
            {
                transform.position = MovementLeft;
                Debug.Log("Moved Left");
                Mov--;
            }
            if (Input.GetKeyDown(KeyCode.D) && WalkableSpace(MovementRight))
            {
                transform.position = MovementRight;
                Debug.Log("Moved Left");
                Mov--;
            }
            if (Input.GetKeyDown(KeyCode.W) && WalkableSpace(MovementUp))
            {
                transform.position = MovementUp;
                Debug.Log("Moved Left");
                Mov--;
            }
            if (Input.GetKeyDown(KeyCode.S) && WalkableSpace(MovementDown))
            {
                transform.position = MovementDown;
                Debug.Log("Moved Left");
                Mov--;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Moved = true;
                Debug.Log("Stop moving");
            }
        }
        Moved = true;
    }

    public bool WalkableSpace(Vector3 MovDir)
    {
        if (Physics.Linecast(transform.position, MovDir))
        {
            return false;
        }
        return true;
    }

    public void MovementReset()
    {
        Debug.Log("reset Movement");
        Moved = false;
        Mov = 5;
    }
}
