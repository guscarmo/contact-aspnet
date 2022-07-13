using System.ComponentModel.DataAnnotations;
using SiteMVC.Enums;

namespace SiteMVC.Models;

public class UserWithoutPasswordModel
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
    public DateTime? UpdateDate { get; set; }
    
}