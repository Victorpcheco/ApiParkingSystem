using System.Text.Json.Serialization;

namespace Api.Enums;


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UsuarioRoleEnum
    {
        Admin,
        User 
    }
