using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToDeckManager : MonoBehaviour
{
    private bool isLinked = false;

    public void DoLink() { isLinked = true; }
    public bool IsLinked() { return isLinked; }
}
