using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IdentifiersApi2.Models;

namespace IdentifiersApi2.Controllers
{
    public class TagModelsController : ApiController
    {
        private IdentifiersContext db = new IdentifiersContext();

        // GET: api/TagModels
        public IQueryable<TagModel> GetTags()
        {
            return db.Tags;
        }

        // GET: api/TagModels/5
        [ResponseType(typeof(TagModel))]
        public IHttpActionResult GetTagModel(int id)
        {
            TagModel tagModel = db.Tags.Find(id);
            if (tagModel == null)
            {
                return NotFound();
            }

            return Ok(tagModel);
        }

        // PUT: api/TagModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTagModel(int id, TagModel tagModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tagModel.ID)
            {
                return BadRequest();
            }

            db.Entry(tagModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TagModels
        [ResponseType(typeof(TagModel))]
        public IHttpActionResult PostTagModel(TagModel tagModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tags.Add(tagModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tagModel.ID }, tagModel);
        }

        // DELETE: api/TagModels/5
        [ResponseType(typeof(TagModel))]
        public IHttpActionResult DeleteTagModel(int id)
        {
            TagModel tagModel = db.Tags.Find(id);
            if (tagModel == null)
            {
                return NotFound();
            }

            db.Tags.Remove(tagModel);
            db.SaveChanges();

            return Ok(tagModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagModelExists(int id)
        {
            return db.Tags.Count(e => e.ID == id) > 0;
        }
    }
}