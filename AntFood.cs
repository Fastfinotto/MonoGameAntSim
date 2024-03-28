using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameAntSim;

public class AntFood
{
    
    
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public int FoodLeft;

    public AntFood(Texture2D texture, Vector2 position, int foodLeft)
    {
        Texture = texture;
        Position = position;
        FoodLeft = foodLeft;
    }
    

}