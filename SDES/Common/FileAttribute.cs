namespace ForensicsCourseToolkit.Common
{
    public  enum FileAttribute : byte
    {
        ReadOnly = 0x01,
        HiddenFile = 0x02,
        SystemFile = 0x04,
        VolumeLabel = 0x08,

        LongFileName = 0x0F,

        Directory = 0x10,
        Archive = 0x20,

    }
}