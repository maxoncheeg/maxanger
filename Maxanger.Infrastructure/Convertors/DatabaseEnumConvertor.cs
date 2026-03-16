namespace Maxanger.Infrastructure.Convertors;

public static class DatabaseEnumConvertor
{
    public static string ConvertToString<TEnum>(TEnum value) where TEnum : struct, Enum
    {
        return value.ToString().ToLower();
    }

    public static TEnum ConvertStringToEnum<TEnum>(string value) where TEnum : struct, Enum
    {
        if (Enum.TryParse(value, out TEnum result))
        {
            return result;
        }
        
        throw new InvalidCastException($"Не удалось конвертировать enum {typeof(TEnum).Name}");
    }
}