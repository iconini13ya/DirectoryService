namespace DirectoryService.Entities;

public class Position
{
	private List<Department> _departments = [];

	public Position(
		string name,
		DateTime createdAt,
		DateTime updatedAt,
		string? description,
		bool? isActive,
		IEnumerable<Department> departments)
	{
		Id = Guid.NewGuid();
		Name = name;
		Description = description;
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

	public Guid Id { get; private set; }

	public string Name
	{
		get { return Name; }
		private set
		{
			if (string.IsNullOrWhiteSpace(value) || value.Length > 100 || value.Length < 3)
			{
				throw new ArgumentException("Property name should not be empty, less than 3 and bigger than 100 symbols");
			}

			// Добавить логику обработки уникального значения
			Name = value;
		}
	}

	public string? Description
	{
		get { return Description; }
		private set
		{
			if (value?.Length > 1000)
			{
				throw new ArgumentException("Property description should not be bigger than 1000 symbols");
			}

			Description = value;
		}
	}

	public bool IsActive { get; set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<Department> Departments => _departments;
}

