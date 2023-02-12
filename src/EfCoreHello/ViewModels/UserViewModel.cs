using System.ComponentModel.DataAnnotations;

namespace EfCoreHello.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [MaxLength(20)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
