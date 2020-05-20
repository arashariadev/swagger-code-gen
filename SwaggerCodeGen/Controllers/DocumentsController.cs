using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerCodeGen.Models;

namespace SwaggerCodeGen.Controllers
{
    /// <summary>
    /// Documents archive related endpoints
    /// </summary>
    [ApiController, Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class DocumentsController : ControllerBase
    {
        private static readonly List<Document> Archive = new List<Document>();
        
        /// <summary>
        /// Returns single document
        /// </summary>
        /// <param name="id">Document identifier</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Document> GetById([FromRoute]string id)
        {
            var result = Archive.FirstOrDefault(d => d.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }
        
        /// <summary>
        /// Returns list of documents
        /// </summary>
        /// <param name="queryString">Query to filter results by title</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Document>> GetList([FromQuery(Name = "q")]string queryString)
        {
            var result = Archive;
            if (!string.IsNullOrEmpty(queryString))
            {
                result = result
                    .Where(d => d.Title.ToLower().Contains(queryString.ToLower()))
                    .ToList();
            }
            
            return Ok(result);
        }

        /// <summary>
        /// Add new document to archive
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody]CreateDocumentCommand model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newDocument = new Document(Guid.NewGuid().ToString(), model.Title, model.Description ?? string.Empty);
            Archive.Add(newDocument);

            return CreatedAtAction(nameof(GetById), new {id = newDocument.Id}, newDocument);
        }
    }
}