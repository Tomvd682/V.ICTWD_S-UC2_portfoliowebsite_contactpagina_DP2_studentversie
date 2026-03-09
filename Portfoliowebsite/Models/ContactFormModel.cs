using System.ComponentModel.DataAnnotations;

namespace Portfoliowebsite.Models
{
    public class ContactFormModel
    {
        public string? Website { get; set; }

        [Required(ErrorMessage = "Naam is verplicht.")]
        [StringLength(40, ErrorMessage = "Naam mag maximaal 40 tekens bevatten.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-mail is verplicht.")]
        [EmailAddress(ErrorMessage = "Voer een geldig e-mailadres in.")]
        [StringLength(100, ErrorMessage = "E-mail mag maximaal 100 tekens bevatten.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Onderwerp is verplicht.")]
        [StringLength(40, ErrorMessage = "Onderwerp mag maximaal 40 tekens bevatten.")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bericht is verplicht.")]
        [StringLength(1234, ErrorMessage = "Bericht mag maximaal 1234 tekens bevatten.")]
        public string Message { get; set; } = string.Empty;
    }
}
