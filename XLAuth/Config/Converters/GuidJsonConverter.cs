using System;
using Newtonsoft.Json;

namespace XLAuth.Config.Converters;

/// <summary>
/// JSON converter for <see cref="TSource:System.Guid"/>.
/// <seealso href="https://gist.github.com/ReubenBond/9416e7a4c528eab473fd"/>
/// </summary>
internal sealed class GuidJsonConverter : JsonConverter<Guid> {
  /// <summary>
  /// Gets a value indicating whether this <see cref="TSource:Newtonsoft.Json.JsonConverter"/> can write JSON.
  /// </summary>
  /// <value><see langword="true"/> if this <see cref="TSource:Newtonsoft.Json.JsonConverter}"/> can write JSON; otherwise, <see langword="false"/>.</value>
  public override bool CanWrite => true;

  /// <summary>
  /// Writes the JSON representation of the object.
  /// </summary>
  /// <param name="writer">The <see cref="TSource:Newtonsoft.Json.JsonWriter"/> to write to.</param>
  /// <param name="value">The value.</param>
  /// <param name="serializer">The calling serializer.</param>
  public override void WriteJson(JsonWriter writer, Guid value, JsonSerializer serializer) {
    writer.WriteValue(value.ToString("B"));
  }

  /// <summary>
  /// Reads the JSON representation of the object.
  /// </summary>
  /// <param name="reader">The <see cref="TSource:Newtonsoft.Json.JsonReader"/> to read from.</param>
  /// <param name="objectType">Kind of the object.</param>
  /// <param name="existingValue">The existing value of object being read.</param>
  /// <param name="hasExistingValue">Determines if there is an existing value.</param>
  /// <param name="serializer">The calling serializer.</param>
  /// <returns>The object value.</returns>
  public override Guid ReadJson(JsonReader reader, Type objectType, Guid existingValue, bool hasExistingValue, JsonSerializer serializer) {
    return reader.Value is string str && Guid.TryParseExact(str, "B", out var guid) ? guid : default;
  }
}
