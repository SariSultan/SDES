using System.Collections.Generic;

namespace ForensicsCourseToolkit.Common
{
    public interface IHaveStructure
    {
        List<StructureUnit> Structure { get; set; }
    }
}