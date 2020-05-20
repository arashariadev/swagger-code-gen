using System.ComponentModel.DataAnnotations;

namespace SwaggerCodeGen.Models
{
    /// <summary>
    /// Command to create new document
    /// </summary>
    public class CreateDocumentCommand
    {
        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; }
        
        /// <summary>
        /// Displayed text
        /// </summary>
        public string Description { get; set; }
    }
}