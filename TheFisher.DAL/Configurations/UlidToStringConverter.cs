using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TheFisher.DAL.Configurations;

public class UlidToStringConverter : ValueConverter<Ulid, string>
{
    public UlidToStringConverter() : base(
        ulid => ulid.ToString(),
        str => string.IsNullOrEmpty(str) ? Ulid.Empty : Ulid.Parse(str))
    {
    }
} 