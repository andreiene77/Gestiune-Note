using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using GestiuneNote.Domain;

namespace GestiuneNote
{
    public class XmlRepo<E, ID> : Repo<E, ID> where E : IHasID<ID>, new()
    {
        protected string fileName;

        public XmlRepo(string fileName)
        {
            this.fileName = fileName;
            if (File.Exists("XMLs/" + fileName))
            {
                LoadData();
            }
            else
            {
                new XDocument(
                    new XElement("root")
                ).Save("XMLs/" + fileName);
            }
        }

        private void LoadData()
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var repoFilepath = Path.Combine(currentDirectory, "XMLs/", fileName);

                XDocument xRepoDoc = XDocument.Load($"{repoFilepath}");

                var elems = xRepoDoc.Root.Elements().ToList();
                foreach (var elem in elems)
                {
                    base.Save(ExtractEntity(elem));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected E ExtractEntity(XElement elem)
        {
            var entity = new E();
            entity.CreateEntityFromElement(elem);
            return entity;
        }

        private void WriteAllToFile()
        {
            try
            {
                XDocument xRepoDoc = new XDocument(
                    new XElement("root")
                );
                Entities.Values.ToList().ForEach(entity => xRepoDoc.Root.Add(entity.CreateElementFromEntity()));
                xRepoDoc.Save("XMLs/" + fileName);
            } 
            catch (Exception e)
            {
                throw e;
            }
        }
        public override void Save(E entity)
        {
            base.Save(entity);
            WriteAllToFile();
        }

        public override void Update(E entity)
        {
            base.Update(entity);
            WriteAllToFile();
        }
    }
}
