using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ColorInventer : MonoBehaviour
{
    private GameManager G;
    private void Start()
    {
        G = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            InvertColor();
            Destroy(gameObject);
            
        }
    }

    public void InvertColor()
    {   
        foreach (ColorChanger obj in G.objs)
        {
            if(obj.gameObject.GetComponent<SpriteRenderer>().color == Color.white)
            {
                if(obj != null)
                obj.ChangeColor(Color.black);
            }
            else if(obj.gameObject.GetComponent<SpriteRenderer>().color == Color.black)
            {
                if (obj != null)
                    obj.ChangeColor(Color.white);
            }
        }

        foreach (TilemapChanger obj in G.tileObjs)
        {
            if (obj.gameObject.GetComponent<Tilemap>().color == Color.white)
            {
                if (obj != null)
                    obj.ChangeColor(Color.black);
            }
            else if (obj.gameObject.GetComponent<Tilemap>().color == Color.black)
            {
                if (obj != null)
                    obj.ChangeColor(Color.white);
            }
        }

        if(G.textObj.gameObject.GetComponent<Text>().color.r == 1 && G.textObj.gameObject.GetComponent<Text>().color.g == 0)
        {
            return;
        }
        else if (G.textObj.gameObject.GetComponent<Text>().color.r == 1 && G.textObj.gameObject.GetComponent<Text>().color.g == 1)
        {
            G.textObj.ChangeColor(Color.black);
        }
        else if (G.textObj.gameObject.GetComponent<Text>().color.r == 0)
        {
            G.textObj.ChangeColor(Color.white);
        }
    }
}
