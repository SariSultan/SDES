using System;

namespace ForensicsCourseToolkit.Framework_Project.Security
{
    [Serializable]
    public enum FilterationSecurityLevel : short
    {
        Moderate = 1, // this one protects against external adversaries that does not have SharedExamKey KE
        High, // this protects agains external and internal adversaries that have KE
    }
}