using System.ComponentModel.DataAnnotations;

namespace ApsiyonCaseStudy.Web.Models
{
    public class LoggerViewModel
    {
        [Required(ErrorMessage = "Lütfen boş bırakmayınız.")]
        public string Message { get; set; }

        //[Required(ErrorMessage = "Lütfen boş bırakmayınız.")]
        public object ObjectModel { get; set; }
    }
}
