using core.Models;
using core.Interfaces;

namespace core.Services;

public class NutServise : INutService
{
    private List<NutDetails> Nuts { get; }
    private int nextId = 3;

    public NutServise()
    {
        Nuts = new List<NutDetails>
        {
            new NutDetails { Id = 1, Date = DateOnly.FromDateTime(DateTime.Now), Name = "פריט 1", Weight = 150 },
            new NutDetails { Id = 2, Date = DateOnly.FromDateTime(DateTime.Now), Name = "פריט 2", Weight = 250 }
        };
    }

    public List<NutDetails> GetAll() => Nuts;

    public NutDetails? Get(int id) => Nuts.FirstOrDefault(n => n.Id == id);

    public void Add(NutDetails nut)
    {
        nut.Id = nextId++;
        Nuts.Add(nut);
    }

    public void Delete(int id)
    {
        var nut = Get(id);
        if (nut is null)
            return;

        Nuts.Remove(nut);
    }

    public void Update(int id, NutDetails nut)
    {
        var index = Nuts.FindIndex(n => n.Id == id);
        if (index == -1)
            return;

        nut.Id = id;
        Nuts[index] = nut;
    }

    public int Count => Nuts.Count;
}
