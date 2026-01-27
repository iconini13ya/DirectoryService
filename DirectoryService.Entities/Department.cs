using System.Text;
using System.Text.RegularExpressions;

namespace DirectoryService.Entities;
public class Department
{
	private List<Location> _locations = [];
	private List<Position> _positions = [];

	public Department(
		string name,
		string identifier, 
		string depth, 
		Department? parent,
		DateTime createdAt,
		DateTime updatedAt,
		IEnumerable<Location> locations,
		IEnumerable<Position> positions)
	{
		Id = Guid.NewGuid();
		Name = name;
		Identifier = identifier;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		IsActive = true;
		Path = CalculatePath(parent);
		Depth = CalculateDepth(parent);
		_locations = GetLocations(locations);
		_positions = GetPositions(positions);
	}

	private string CalculatePath(Department? parent)
	{
		if (parent is not null)
		{
			StringBuilder sb = new StringBuilder(parent.Path);
			sb.Append(".");
			sb.Append(Identifier);
			return sb.ToString();
		}
		return Identifier;
	}

	private short CalculateDepth(Department? parent)
	{
		if (parent is not null)
		{
			return parent.Depth++;
		}
		return 1;
	}

	private List<Location> GetLocations(IEnumerable<Location> locations)
	{
		if (locations == null || !locations.Any())
		{
			throw new ArgumentException("Property locations should contain at least one item");
		}
		return locations.ToList();
	}

	private List<Position> GetPositions(IEnumerable<Position> positions)
	{
		if (positions == null || !positions.Any())
		{
			throw new ArgumentException("Property positions should contain at least one item");
		}
		return positions.ToList();
	}

	#region properties
	public Guid Id { get; private set; }

	public string Name
	{
		get { return Name; }
		private set 
		{
			if (string.IsNullOrWhiteSpace(value) || value.Length > 150 || value.Length < 3)
			{
				throw new ArgumentException("Property name should not be empty, less than 3 and bigger than 150 symbols");
			}

			Name = value;
		}
	}

	public string Identifier 
	{
		get { return Identifier ; }

		private set 
		{

			if (string.IsNullOrWhiteSpace(value) || value.Length > 30 || value.Length < 3 || !Regex.IsMatch(value, @"^[a-zA-Z]+$"))
			{
				throw new ArgumentException($"Property identifier should not be empty, less than 3 and bigger than 30 symbols and contains only latin alphabet");
			}

			Identifier = value;
		}
	}

	public Department? Parent { get; private set; }

	public string Path { get; private set; }

	public short Depth { get; private set; }

	public bool IsActive { get; set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime UpdatedAt { get; private set; }

	public IReadOnlyList<Location> Locations => _locations;

	public IReadOnlyList<Position> Positions => _positions;
	#endregion
}