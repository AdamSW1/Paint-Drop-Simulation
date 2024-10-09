using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShapeLibrary;
using System.Collections.Generic;

namespace PaintDrops;

public class PaintDropsGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ISpritesRenderer spritesRenderer;   
    private IShapesRenderer shapesRenderer;
    private Screen _screen;
    private ICustomKeyboard customKeyboard = CustomKeyboard._instance;
    private ICustomMouse customMouse = CustomMouse._instance;

    private List<ICircle> _circles = new();
    private List<IRectangle> _rectangles = new();

    public PaintDropsGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        spritesRenderer = new SpritesRenderer(GraphicsDevice);
        shapesRenderer = new ShapesRenderer(GraphicsDevice);
        _screen = new(new RenderTarget2D(GraphicsDevice, 640, 480));
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        customMouse.Update();
        customKeyboard.Update();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (customKeyboard.IsKeyClicked(Keys.Escape))
        {
            this.Exit();
        }

        Vector2? mousePos = customMouse.GetScreenPosition(_screen);

        if(mousePos is not null && customMouse.IsLeftButtonClicked())
        {
            ICircle circle = ShapesFactory.CreateCircle(mousePos.Value.X, mousePos.Value.Y, 50, new Colour(255, 0, 0));
            _circles.Add(circle);
        }
        if (mousePos is not null && customMouse.IsRightButtonClicked()) {
            IRectangle rectangle = ShapesFactory.CreateRectangle(mousePos.Value.X, mousePos.Value.Y, 50, 50, new Colour(0, 0, 255));
            _rectangles.Add(rectangle);
        }

        if (customMouse.IsMiddleButtonClicked()) {
            _rectangles.Clear();
            _circles.Clear();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _screen.Set();
        GraphicsDevice.Clear(Color.White);
        shapesRenderer.Begin();
        spritesRenderer.Begin(true);

        foreach (ICircle circle in _circles) { 
            shapesRenderer.DrawShape(circle);
        }

        foreach (IRectangle rectangle in _rectangles) { 
            shapesRenderer.DrawShape(rectangle);
        }
        shapesRenderer.End();
        spritesRenderer.End();
        _screen.UnSet();
        _screen.Present(spritesRenderer);
        base.Draw(gameTime);
    }
}
