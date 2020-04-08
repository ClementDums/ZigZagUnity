using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour
{
    public static GenerateTiles instance;

    public void Awake()
    {
        instance = this;
    }

    Transform currentFinalTile;
    public Transform NewTilesContainer;
    public Transform prefab;
    public Transform piecePrefab;
    public Transform treePrefab;
    public Transform startMap;

    public bool hasTree;

    Transform currentStartMap;
    float randomPosition;
    float randomPiece;
    bool isLeft;
    float width;

    // Start is called before the first frame update
    void Start()
    {

        width = prefab.localScale.x;
        currentStartMap = Instantiate(startMap);
        currentFinalTile = currentStartMap.GetComponent<FinalTile>().prefab;

    }

    public void GenerateMyTile()
    {
        randomPosition = Mathf.Round(Random.value);
        randomPiece = Mathf.Round(Random.value * 4);
        isLeft = randomPosition > 0.9 ? true : false;
        Transform clone = Instantiate(prefab, NewTilesContainer);

        //On the left
        if (isLeft)
        {
            clone.position = new Vector3(currentFinalTile.position.x - width, prefab.position.y, currentFinalTile.position.z);
        }
        else
        {
            //on the right
            clone.position = new Vector3(currentFinalTile.position.x, prefab.position.y, currentFinalTile.position.z + width);
        }

        //Generate piece
        if (randomPiece > 3)
        {
            Transform piece = Instantiate(piecePrefab,clone);
            piece.position = new Vector3(clone.position.x, -3, clone.position.z);
        }
        else if(hasTree && randomPiece<2)
        {
            Transform tree = Instantiate(treePrefab, clone);
            tree.position = new Vector3(clone.position.x, -3, clone.position.z);
        }

        currentFinalTile = clone;
    }

    public void StartGeneration()
    {
        ResetStartMap();
        ClearTiles();
        ResetTileGeneration();
        
    }


    void ResetStartMap()
    {
        Destroy(currentStartMap.gameObject);
        currentStartMap = Instantiate(startMap);

    }

    void ResetTileGeneration()
    {

        currentFinalTile = startMap.GetComponent<FinalTile>().prefab; 
    }

    void ClearTiles()
    {
        foreach(Transform child in NewTilesContainer)
        {
            Destroy(child.gameObject);
        }
    }
  
}
