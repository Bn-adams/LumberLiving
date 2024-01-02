using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public interface ISpawner
{
    public GameObject Spawn(GameObject caller);
}
