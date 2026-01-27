namespace DirectoryService.Entities;

public class Location
{
	private List<Department> _departments = [];


	public Location(
		string name, 
		string address,
		string timeZone,
		DateTime createdAt,
		DateTime updatedAt,
		IEnumerable<Department> departments,
        bool? isActive)
    { 
		Id = Guid.NewGuid();
		Name = name;
		Address = address;
		TimeZone = timeZone;
		IsActive = isActive ?? true;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		_departments = GetDepartments(departments);
	}

    private List<Department> GetDepartments(IEnumerable<Department> departments)
    {
        if (departments == null || !departments.Any())
        {
            throw new ArgumentException("Property departments should contain at least one item");
        }
        return departments.ToList();
    }

    public Guid Id {  get; private set; }

	public string Name
	{
		get { return Name; }
		private set
		{
			if (string.IsNullOrWhiteSpace(value) || value.Length > 150 || value.Length < 3)
			{
				throw new ArgumentException("Property name should not be empty, less than 3 and bigger than 150 symbols");
			}

			// Добавить логику обработки уникального значения
			Name = value;
		}
	}

	public string Address {get; private set;}

	public string TimeZone 
	{
		get { return TimeZone; } 
		private set
		{
			try
			{
				TimeZoneInfo.FindSystemTimeZoneById(value);
				TimeZone = value;
			}
			catch(Exception e)
			{
				throw new ArgumentException($"Wrong argument {value}, that trigger exception {e}");
			}
		}
	}

	public bool IsActive { get; set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime UpdatedAt { get; private set; }

	public IReadOnlyList<Department> Departments => _departments;
}