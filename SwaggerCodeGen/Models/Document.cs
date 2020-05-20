namespace SwaggerCodeGen.Models
{
    /// <summary>
    /// Class description
    /// </summary>
    public class Document
    {
        public Document(string id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        /// <summary>
        /// Identifier
        /// </summary>
        public string Id { get; }
        
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; }
        
        /// <summary>
        /// Displayed text
        /// </summary>
        public string Content { get; }
    }
}