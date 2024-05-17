using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject[] brickTypes;
    public Transform StartPos;
    public int numRows;
    
    void Start()
    {
        float y = StartPos.position.y;
        float x = StartPos.position.x;
        for (int i = 0; i < numRows; i++)
        {
            y = StartPos.position.y;
            for (int j = 0; j < 9; j++)
            {   
                Instantiate(brickTypes[Random.Range(0, brickTypes.Length)], new Vector2(x, y), Quaternion.identity);
                y -= 1;
            }
            x -= 0.5f;
        }
    }
}
