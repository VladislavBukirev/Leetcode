using NUnit.Framework;

public class UndergroundSystem
{
    Dictionary<int, (string from, int time)> starts;
    Dictionary<(string, string), List<int>> times;
    public UndergroundSystem()
    {
        starts = new Dictionary<int, (string from, int time)>();
        times = new Dictionary<(string, string), List<int>>();  
    }

    public void CheckIn(int id, string stationName, int t)
    {
        starts.TryAdd(id, (string.Empty, 0));
        starts[id] = (stationName, t);
    }

    public void CheckOut(int id, string stationName, int t)
    {
        times.TryAdd((starts[id].from, stationName), new List<int>());
        times[(starts[id].from,stationName)].Add(t - starts[id].time);
        starts.Remove(id);
    }

    public double GetAverageTime(string startStation, string endStation) 
        => Math.Round(times[(startStation,endStation)].Average(), 5);
}

public class UndergroundSystemTests
{
    [Test]
    public void TestUndergroundSystemFirst()
    {
        var undergroundSystem = new UndergroundSystem();
        undergroundSystem.CheckIn(45, "Leyton", 3);
        undergroundSystem.CheckIn(32, "Paradise", 8);
        undergroundSystem.CheckIn(27, "Leyton", 10);
        undergroundSystem.CheckOut(45, "Waterloo", 15);  
        undergroundSystem.CheckOut(27, "Waterloo", 20); 
        undergroundSystem.CheckOut(32, "Cambridge", 22); 
        var paradiseCambridge = undergroundSystem.GetAverageTime("Paradise", "Cambridge");
        Assert.AreEqual(14, paradiseCambridge);
        var leytonWaterlooFirst = undergroundSystem.GetAverageTime("Leyton", "Waterloo");  
        Assert.AreEqual(11, leytonWaterlooFirst);
        undergroundSystem.CheckIn(10, "Leyton", 24);
        var leytonWaterlooSecond = undergroundSystem.GetAverageTime("Leyton", "Waterloo");    
        Assert.AreEqual(11, leytonWaterlooSecond);
        undergroundSystem.CheckOut(10, "Waterloo", 38);  
        var leytonWaterlooThird = undergroundSystem.GetAverageTime("Leyton", "Waterloo");   
        Assert.AreEqual(12, leytonWaterlooThird);
    }

    [Test]
    public void TestUndergroundSystemSecond()
    {
        var undergroundSystem = new UndergroundSystem();
        undergroundSystem.CheckIn(10, "Leyton", 3);
        undergroundSystem.CheckOut(10, "Paradise", 8); // Customer 10 "Leyton" -> "Paradise" in 8-3 = 5
        var leytonParadiseFirst = undergroundSystem.GetAverageTime("Leyton", "Paradise"); // return 5.00000, (5) / 1 = 5
        Assert.AreEqual(5, leytonParadiseFirst);
        undergroundSystem.CheckIn(5, "Leyton", 10);
        undergroundSystem.CheckOut(5, "Paradise", 16); // Customer 5 "Leyton" -> "Paradise" in 16-10 = 6
        var leytonParadiseSecond = undergroundSystem.GetAverageTime("Leyton", "Paradise"); // return 5.50000, (5 + 6) / 2 = 5.5
        Assert.AreEqual(5.5, leytonParadiseSecond);
        undergroundSystem.CheckIn(2, "Leyton", 21);
        undergroundSystem.CheckOut(2, "Paradise", 30); // Customer 2 "Leyton" -> "Paradise" in 30-21 = 9
        var leytonParadiseThird = undergroundSystem.GetAverageTime("Leyton", "Paradise"); // return 6.66667, (5 + 6 + 9) / 3 = 6.66667
        Assert.AreEqual(6.66667, leytonParadiseThird);
    }
}