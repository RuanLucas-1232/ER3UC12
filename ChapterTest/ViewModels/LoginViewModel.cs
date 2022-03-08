using System.ComponentModel.DataAnnotations;

namespace ChapterTest
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Email de Login")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe o Email de Login")]
        public string senha { get; set; }

    }
}
