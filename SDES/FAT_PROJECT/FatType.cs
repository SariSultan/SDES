namespace ForensicsCourseToolkit.FAT_PROJECT
{
    public enum FatType : short
    {
        NotSet=0,//This should throw error if found in boot sector
        Fat12,
        Fat16,
        Fat32
    }
}