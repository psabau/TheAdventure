using Silk.NET.Maths;
using Silk.NET.SDL;

namespace TheAdventure.Models;
public class VolumeControl : RenderableGameObject
{
    public enum Action
    {
        IncreaseVolume,
        DecreaseVolume
    }

    private Action _action;
    public Rectangle<int> InteractionArea { get; private set; }

    public VolumeControl(SpriteSheet spriteSheet, (int X, int Y) position, Action action, double angle = 0, Point rotationCenter = new Point()) 
        : base(spriteSheet, position, angle, rotationCenter)
    {
        _action = action;
        InteractionArea = new Rectangle<int>(position.X, position.Y, 32, 32);
    }

    public void TriggerAction(MusicPlayer player)
    {
        switch (_action)
        {
            case Action.IncreaseVolume:
                player.SetVolume(player.CurrentVolume + 0.1f);
                break;
            case Action.DecreaseVolume:
                player.SetVolume(player.CurrentVolume - 0.1f);
                break;
        }
    }
    
    public bool IsWithinInteractionArea(int x, int y)
    {
        return InteractionArea.Contains(new Vector2D<int>(x, y));
    }
}