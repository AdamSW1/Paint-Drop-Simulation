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

    private List<ICircle> _circles;
    private List<IRectangle> _rectangles;

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
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _screen.Set();
        GraphicsDevice.Clear(Color.White);
        shapesRenderer.Begin();
        spritesRenderer.Begin(true);

        // TODO: Add your drawing code here
        shapesRenderer.End();
        spritesRenderer.End();
        _screen.UnSet();
        _screen.Present(spritesRenderer);
        base.Draw(gameTime);
    }
}
