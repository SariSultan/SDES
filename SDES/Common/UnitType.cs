namespace ForensicsCourseToolkit.Common
{
    public enum UnitType : short
    {
        Default = 0,
        Vbr,
        SizeInSectorsLittleEndian,
        LittleEndianHex,
        Ascii,
        TimeTenthofSeconds,
        TimeHms,
        Day,
        SizeInBytes,
        FatDirectoryEntryAttributes,
        LongFileNameFatDirectory,
    }
}