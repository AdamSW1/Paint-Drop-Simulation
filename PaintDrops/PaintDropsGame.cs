using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PaintDropSimulation;
using PatternGenerationLib;
using ShapeLibrary;
using System;

namespace PaintDrops;

public class PaintDropsGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ISpritesRenderer spritesRenderer;   
    private IShapesRenderer shapesRenderer;
    private IScreen _screen;
    private ICustomKeyboard customKeyboard = CustomKeyboard._instance;
    private ICustomMouse customMouse = CustomMouse._instance;
    private IPatternGenerator patternGeneration;
    private bool generatePattern = false;


    private ISurface surface;

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
        _screen = new Screen(new RenderTarget2D(GraphicsDevice, 640, 480));
        surface = PaintDropSimulationFactory.CreateSurface(640, 480);

        patternGeneration = PatternGenerationFactory.CreatePattern("phyllotaxis");
        surface.OnCalculatePatternPoint += patternGeneration.CalculatePatternPoint;
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

        if (customMouse.IsLeftButtonClicked())
        {
            Vector2? mousePos = customMouse.GetScreenPosition(_screen);
            if(mousePos is not null)
            {
                ICircle circle = ShapesFactory.CreateCircle(mousePos.Value.X, mousePos.Value.Y, 50, GetRandomColourObject());
                IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
                surface.AddPaintDrop(drop);
            }
        }

        if (customMouse.IsRightButtonClicked())
        {
            Vector2? mousePos = customMouse.GetScreenPosition(_screen);
            if (mousePos is not null)
            {
                surface.Drops.Clear();
                patternGeneration.ResetIndex();
            }

        }

        if (customKeyboard.IsKeyClicked(Keys.M))
        {
            generatePattern = true;
        }

        if (customKeyboard.IsKeyClicked(Keys.E))
        {
            generatePattern = false;
        }

        if (generatePattern)
        {
            surface.GeneratePaintDropPattern(10, GetRandomColourObject());
        }

        base.Update(gameTime);
    }

    private int GenerateRandomColour()
    {
        Random rand = new Random();
        //maxValue random.Next() is not inclusive
        int colour = rand.Next(0, 256);
        return colour;
    }

    private Colour GetRandomColourObject()
    {
        int red = GenerateRandomColour();
        int green = GenerateRandomColour();
        int blue = GenerateRandomColour();

        return new Colour(red, green, blue);
    }

    protected override void Draw(GameTime gameTime)
    {
        _screen.Set();
        GraphicsDevice.Clear(Color.White);
        shapesRenderer.Begin();
        spritesRenderer.Begin(true);

        foreach( IPaintDrop drop in surface.Drops)
        {
            shapesRenderer.DrawShape(drop.Circle);
        }

        shapesRenderer.End();
        spritesRenderer.End();
        _screen.UnSet();
        _screen.Present(spritesRenderer);
        base.Draw(gameTime);
    }
}
