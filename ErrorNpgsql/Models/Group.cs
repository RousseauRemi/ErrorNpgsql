using NetTopologySuite.Geometries;

namespace ErrorNpgsql.Models;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Point Position { get; set; }
    public List<Zone>? Zones { get; set; }

}