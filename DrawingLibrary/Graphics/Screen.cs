using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace DrawingLibrary.Graphics;
public class Screen : IScreen
{
    RenderTarget2D RenderTarget;

    public Screen(RenderTarget2D target)
    {
        RenderTarget = target;
        Height = RenderTarget.Height;
        Width = RenderTarget.Width;
    }

    public int Height { get; set; }

    public int Width { get; set; }

    public Rectangle CalculateDestinationRectangle()
    {

        float screenWidth = Width;
        float screenHeight = Height;
        float windowWidth = RenderTarget.GraphicsDevice.PresentationParameters.Bounds.Width;
        float windowHeight = RenderTarget.GraphicsDevice.PresentationParameters.Bounds.Height;
        float aspectRatio = screenWidth / screenHeight;
        int x = 0;
        int y = 0;

        if (screenWidth < windowWidth)
        {
            screenHeight = windowHeight;
            screenWidth = windowHeight * aspectRatio;
            x = (int)(windowWidth - screenWidth) / 2;
        }
        else
        {
            screenWidth = windowWidth;
            screenHeight = windowWidth / aspectRatio;
            y = (int)(windowHeight - screenHeight) / 2;
        }

        Rectangle rectangle = new(x, y, (int)screenWidth, (int)screenHeight);

        return rectangle;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Present(ISpritesRenderer spritesRenderer, bool textureFiltering = true)
    {
        if (spritesRenderer == null)
        {
            throw new ArgumentNullException("Null sprite renderer");
        }
        spritesRenderer.Begin(textureFiltering);
        spritesRenderer.Draw(RenderTarget, CalculateDestinationRectangle(), Color.White);
        spritesRenderer.End();

    }

    public void Set()
    {
        if (RenderTarget.GraphicsDevice.RenderTargetCount != 0)
        {
            throw new InvalidOperationException("render target already set");
        }
        RenderTarget.GraphicsDevice.SetRenderTarget(RenderTarget);
    }

    public void UnSet()
    {
        if (RenderTarget.GraphicsDevice.RenderTargetCount == 0)
        {
            throw new InvalidOperationException("no render target set");
        }
        RenderTarget.GraphicsDevice.SetRenderTarget(null);
    }
}
