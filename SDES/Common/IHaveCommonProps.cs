using ForensicsCourseToolkit.Common.Helpers;

namespace ForensicsCourseToolkit.Common
{
    public interface IHaveCommonProps
    {
        Logger Logger { get; set; }
        string RawValue { get; set; }
        int Size { get;  }

        string Description { get; set; }
        
    }
}