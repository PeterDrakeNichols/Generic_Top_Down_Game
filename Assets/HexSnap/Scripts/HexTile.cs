using UnityEngine;
using System.Collections;

public class HexTile : MonoBehaviour {

    public int x, z, layer;
    public bool visited = false;
    
    public virtual void Start()
    {
        this.name = "hexTile," + x + "," + z + "," + layer;
    }
}
