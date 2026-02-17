namespace DirectoryService.Entities.Department;

public class DepartmentChild
{
    // EF Core
    private DepartmentChild() { }

    public DepartmentChild(
    Guid id,
    Guid parentId,
    Guid childId)
    {
        Id = id;
        ParentId = parentId;
        ChildId = childId;
    }

    public Guid Id { get; private set; }

    public Guid ParentId { get; private set; }

    public Guid ChildId { get; private set; }
}
