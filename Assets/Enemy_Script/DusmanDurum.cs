using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DusmanDurum 
{
    void Enter(Dusman dusman);
    void Execute();
    void Exit();
    void OnTriggerEnter2D(Collider2D collider);
}
