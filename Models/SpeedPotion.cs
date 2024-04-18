using Silk.NET.Maths;
using Silk.NET.SDL;

namespace TheAdventure.Models;

public class SpeedPotion : RenderableGameObject
{
    public int SpeedBoost { get; }
    public double Duration { get; }
    public Rectangle<int> InteractionArea { get; }

    public SpeedPotion(SpriteSheet spriteSheet, (int X, int Y) position, int speedBoost, double duration, double angle = 0, Point rotationCenter = new Point())
        : base(spriteSheet, position, angle, rotationCenter)
    {
        SpeedBoost = speedBoost;
        Duration = duration;
        InteractionArea = new Rectangle<int>(position.X, position.Y, 32, 32);
    }
    
    public bool IsWithinInteractionArea(int x, int y)
    {
        return InteractionArea.Contains(new Vector2D<int>(x, y));
    }
}