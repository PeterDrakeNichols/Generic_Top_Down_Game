using UnityEngine;
using System.Collections;

// converts World Coordinates to Hexgon coordinates and vice versa 
// stores Converted mouse coordinates in tileHexPosition and TileWorldPosition
// finds the specific Hexagon cell the mouse is currently occupying
// based on brnkhy's "Coordinate Calculations in Hexagonal World"
// barankahyaoglu.com/dev/coordinate-calculations-in-hexagonal-world/

public class HexSnap : MonoBehaviour {
    //just here for testing do not reference
    public Vector3 tileHexPosition;
    public Vector3 tileWorldPosition;
 
    void Update(){     
        //just here for testing 
        if (Input.GetMouseButtonDown(3)){
            tileHexPosition = WorldToHex(GetComponent<MouseVectors>().MouseToGround().point);
            tileWorldPosition = HexToWorld(tileHexPosition);
        }
    }
    public Vector3 HexToWorld(Vector3 hexCoordinate){
        return new Vector3(hexCoordinate.x * HexValues.width +(HexValues.width / 2) +(((int) hexCoordinate.z & 1) * HexValues.width / 2), hexCoordinate.y,hexCoordinate.z * HexValues. rowheight + HexValues.height / 2);
    }

    public Vector3 WorldToHex(Vector3 worldPosition){
        Vector3 hexCoordinates = new Vector3(Mathf.Floor(worldPosition.x / HexValues.width), 1, Mathf.Floor(worldPosition.z / HexValues.rowheight));
        bool offsetRow = false;
        float modX = (worldPosition.x % HexValues.width); 
        float modZ = (worldPosition.z % HexValues.rowheight);
        float resultX = 0;
        float resultZ = 0;
        if ((hexCoordinates.z % 2) == 0)
            offsetRow = true;
        else
            offsetRow = false;
        if (offsetRow ==  true){ //if we are in an offset row find Middle, left, or right hexagon
             resultX = 0;
             resultZ = 0;
            if(modZ < (HexValues.extraHeight - modX * HexValues.hypotenuse)){
                resultX =  - 1;
                resultZ =  - 1;
            }
            if(modZ < (-HexValues.extraHeight + modX * HexValues.hypotenuse)){
                resultX = 0;
                resultZ =-1;
            }
        }
        else{
            if(modX >= HexValues.halfWidth){
                if(modZ < (2* HexValues.extraHeight - modX * HexValues.hypotenuse)){
                    resultX = 0;
                    resultZ = -1;
                }
            }
            else{
                resultX = 0;
                resultZ = 0;
            }
            if (modX < HexValues.halfWidth){
                if (modZ < (modX * HexValues.hypotenuse)){
                    resultX = 0;
                    resultZ = -1;
                }
                else{
                    resultX = -1;
                    resultZ = 0;
                }
            }
        }
        return new Vector3(hexCoordinates.x + resultX,.1f,hexCoordinates.z + resultZ);
    }
}


