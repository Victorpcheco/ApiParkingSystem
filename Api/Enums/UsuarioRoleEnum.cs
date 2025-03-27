using System.Text.Json.Serialization;

namespace Api.Enums;


    [JsonConverter(typeof(JsonStringEnumConverter))] // Adicione esta anotação
    public enum UsuarioRoleEnum
    {
        Admin,
        User 
    }
