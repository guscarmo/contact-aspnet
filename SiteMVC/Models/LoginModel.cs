using System.ComponentModel.DataAnnotations;
namespace SiteMVC.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Digite o login")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Senha inválida")]
    public string Password { get; set; }
    
}