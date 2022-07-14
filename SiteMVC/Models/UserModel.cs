using System.ComponentModel.DataAnnotations;
using SiteMVC.Enums;

namespace SiteMVC.Models;

public class UserModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Digite o nome do usuário")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Digite o login do usuário")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Digite o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Informe o perfil do usuário")]
    public PerfilEnum? Perfil{ get; set; }
    [Required(ErrorMessage = "Digite a senha do usuário")]
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public bool ValidPassword(string password)
    {
        return Password == password;
    }
    
}