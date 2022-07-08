using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models;

public class ContactModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Digite o nome do contato")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Digite o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido!")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Insira o celular")]
    [Phone(ErrorMessage = "Telefone inválido")]
    public string Celular { get; set; }
    
    
}