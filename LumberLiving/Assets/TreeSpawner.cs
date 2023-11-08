using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    public GameObject Spawn(GameObject caller)
    {
        GameObject Tree = Instantiate(tree);
        Tree.transform.SetParent(caller.transform);

        return Tree;
    }
}
    

