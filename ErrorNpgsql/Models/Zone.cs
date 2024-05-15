
using NetTopologySuite.Geometries;

namespace ErrorNpgsql.Models;

public class Zone
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public List<Point> Positions { get; set; } = [];
}
