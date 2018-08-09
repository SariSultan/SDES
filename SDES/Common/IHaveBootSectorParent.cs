namespace ForensicsCourseToolkit.Common
{
    public interface IHaveBootSectorParent
    {
        BootSector ParentBootSector { get; set; }
    }
}