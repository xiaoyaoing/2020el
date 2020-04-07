using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAntibodyControl : MonoBehaviour
{
    private int AntibodyAttached = 0;
    private PlayerMoveControl Move;

    void Start()
    {
        Move = GetComponent<PlayerMoveControl>();
    }

    public void AttachAntibody()
    {
        ++AntibodyAttached;
        Move.SetMaxHorizontalSpeed(Move.GetMaxHorizontalSpeed() - 2);
    }

    public int GetAttachedAntibodyCount()
    {
        return AntibodyAttached;
    }
}
