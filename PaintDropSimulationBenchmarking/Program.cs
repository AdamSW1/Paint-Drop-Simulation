using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;

class Benchmarking
{
    public static void Main(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();
        ISurface s1 = PaintDropSimulationFactory.CreateSurface(100, 100);
        Random rand = new();
        for (int i = 0; i < 100; i++) {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(100), rand.Next(100), rand.Next(50), new Colour(0,0,0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s1.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s1 (100, 100) with 100 took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

        ISurface s2 = PaintDropSimulationFactory.CreateSurface(250, 250);
        for (int i = 0; i < 200; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(250), rand.Next(250), rand.Next(50), new Colour(0, 0, 0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s2.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s2 (250, 250) with 200 drops took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

        ISurface s3 = PaintDropSimulationFactory.CreateSurface(500, 500);
        for (int i = 0; i < 500; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(500), rand.Next(500), rand.Next(50), new Colour(0, 0, 0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s2.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s3 (500, 500) with 500 drops took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

        ISurface s4 = PaintDropSimulationFactory.CreateSurface(750, 750);
        for (int i = 0; i < 700; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(750), rand.Next(750), rand.Next(50), new Colour(0, 0, 0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s2.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s4 (750, 750) with 700 drops took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

        ISurface s5 = PaintDropSimulationFactory.CreateSurface(1000, 1000);
        for (int i = 0; i < 1000; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(1000), rand.Next(1000), rand.Next(50), new Colour(0, 0, 0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s2.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s5 (1000, 1000) with 1000 drops took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

        ISurface s6 = PaintDropSimulationFactory.CreateSurface(3000, 3000);
        for (int i = 0; i < 3000; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(3000), rand.Next(3000), rand.Next(50), new Colour(0, 0, 0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s2.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s6 (3000, 3000) with 3000 drops took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

        ISurface s7 = PaintDropSimulationFactory.CreateSurface(4000, 4000);
        for (int i = 0; i < 4000; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(4000), rand.Next(4000), rand.Next(50), new Colour(0, 0, 0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s2.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s7 (4000, 4000) with 4000 drops took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

        ISurface s8 = PaintDropSimulationFactory.CreateSurface(5000, 5000);
        for (int i = 0; i < 5000; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rand.Next(5000), rand.Next(5000), rand.Next(50), new Colour(0, 0, 0));
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            s2.AddPaintDrop(drop);
        }
        sw.Stop();
        Console.WriteLine($"s8 (5000, 5000) with 5000 drops took: {sw.ElapsedMilliseconds}");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        sw.Restart();

    }

}