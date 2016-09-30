using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Infection : MonoBehaviour {

    public Color infectionColor = new Color(0, 0, 0);

    public void StartInfection(List<HexTile> cluster)
    {
        StartCoroutine(SpreadInfection(cluster));
    }

    public IEnumerator SpreadInfection(List<HexTile> cluster)
    {
        
        for(int i = 0; i < cluster.Count; i++)
        {
            yield return new WaitForSeconds(.25f);
            Infect(cluster[i]);
        } 
    }

    public void Infect(HexTile hexTile)
    {
        hexTile.GetComponent<Renderer>().material.SetColor("_Color", infectionColor);
    }

}
