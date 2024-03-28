using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameAntSim;

public class AntMound
{
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public int FoodCloected;

    public AntMound(Texture2D texture, Vector2 position, int foodCloected)
    {
        Texture = texture;
        Position = position;
        FoodCloected = foodCloected;
    }
    
}